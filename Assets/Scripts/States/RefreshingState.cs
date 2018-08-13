using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshingState : IState
{
    private int shotsTillNextRow = 2; // TODO find a better place for this
    private int shotsSinceLastRow = 100;

    private StateManager stateManager;
    private LevelManager levelManager;
    private UpgradeManager upgradeManager;
    private Circle circlePrefab;

    public RefreshingState(StateManager stateManager, LevelManager levelManager, UpgradeManager upgradeManager, Circle circlePrefab)
    {
        this.stateManager = stateManager;
        this.levelManager = levelManager;
        this.upgradeManager = upgradeManager;
        this.circlePrefab = circlePrefab;
    }

    public void Enter()
    {
    }

    public void Update()
    {
        if (this.shotsSinceLastRow >= this.shotsTillNextRow)
        {
            this.shotsSinceLastRow = 0;
            ShiftExistingRows();
            SpawnNextRow();
            upgradeManager.CirclesMoved();
        }

        this.upgradeManager.UpdateRefreshState();

        this.shotsSinceLastRow++;
    }

    public IState NextState()
    {
        return this.stateManager.idleState;
    }

    private void ShiftExistingRows()
    {
        foreach (GameObject circ in GameObject.FindGameObjectsWithTag("Circle"))
        {
            if (circ != null)
            {
                if (circ.transform.position.y < 2)
                {
                    this.levelManager.LoadLevel("GameOver");
                    return;
                }
                circ.transform.position = new Vector3(circ.transform.position.x, circ.transform.position.y - 1, circ.transform.position.z);
            }
        }
    }

    private void SpawnNextRow()
    {
        AddCircle(-2.5f);
        AddCircle(-1.5f);
        AddCircle(-0.5f);
        AddCircle(0.5f);
        AddCircle(1.5f);
        AddCircle(2.5f);
    }

    private void AddCircle(float x)
    {
        GameObject.Instantiate(circlePrefab, new Vector3(x, 8.5f, -2.0f), Quaternion.identity);
    }



}
