using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshingState : IState
{
    private int shotsTillNextRow = 2; // TODO find a better place for this
    private int shotsSinceLastRow = 100;
    private float shiftdownSpeed = 0.1f;
    private int shiftdownSteps;
    private int currentStep;
    private bool nextState;

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
        this.shiftdownSteps = (int)(1.0f / shiftdownSpeed);
    }

    public void Enter()
    {
        this.currentStep = 0;
        this.nextState = false;
    }

    public void Update()
    {
        if (ShouldSpawnNextRow())
        {
            if (ShiftdownComplete())
            {
                this.shotsSinceLastRow = 0;
                SpawnNextRow();
                upgradeManager.CirclesMoved();
                this.nextState = true;
            }
            else
            {
                ShiftExistingRows();
            }
        }
        else
        {
            this.nextState = true;
        }

        this.shotsSinceLastRow++;
    }

    public IState NextState()
    {
        if (nextState)
        {
            if (StaticWriter.round > 0)
            {
                StaticWriter.SendNetworkMessage();
            }
            StaticWriter.round++;
            return this.stateManager.idleState;
        }
        return this;
    }

    private bool ShiftdownComplete()
    {
        return this.currentStep > this.shiftdownSteps;
    }

    private void ShiftExistingRows()
    {
        foreach (GameObject circ in GameObject.FindGameObjectsWithTag("Circle"))
        {
            if (circ != null)
            {
                if (circ.transform.position.y <= 2.5)
                {
                    this.levelManager.LoadLevel("03 GameOver");
                    return;
                }
                circ.transform.position = new Vector3(circ.transform.position.x, circ.transform.position.y - shiftdownSpeed, circ.transform.position.z);
            }
        }
        currentStep++;
    }

    private bool ShouldSpawnNextRow()
    {
        return this.shotsSinceLastRow >= this.shotsTillNextRow;
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
        GameObject.Instantiate(circlePrefab, new Vector3(x, circlePrefab.transform.position.y, circlePrefab.transform.position.z), Quaternion.identity);
    }

    public int RingCount()
    {
        return this.upgradeManager.RingCount();
    }
}
