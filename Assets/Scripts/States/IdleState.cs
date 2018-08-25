using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private ShootingLine shootingLine;
    private StateManager stateManager;
    private Ring staticRing;
    private UpgradeManager upgradeManager;

    public IdleState(StateManager stateManager, ShootingLine shootingLine, Ring staticRing, UpgradeManager upgradeManager)
    {
        this.stateManager = stateManager;
        this.shootingLine = shootingLine;
        this.staticRing = staticRing;
        this.upgradeManager = upgradeManager;
    }

    public void Enter()
    {
        this.shootingLine.SetVisible(true);
        this.staticRing.gameObject.SetActive(true);

        StaticWriter.ringCount = upgradeManager.RingCount();
        StaticWriter.ringDamage = upgradeManager.RingDamage();
        StaticWriter.damageDone = 0;
        StaticWriter.circleSum = 0;
        var circles = GameObject.FindGameObjectsWithTag("Circle");
        StaticWriter.circleCount = circles.Length;
        foreach (GameObject gameObj in circles)
        {
            Circle circ = gameObj.GetComponent<Circle>();
            StaticWriter.circleSum += circ.GetHitsLeft();
        }
    }

    public void Update()
    {

    }

    public IState NextState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.staticRing.transform.position;
            this.stateManager.spawningState.SetDirection(direction);
            return this.stateManager.spawningState;
        }
        return this;
    }

        public int RingCount()
    {
        return this.upgradeManager.RingCount();
    }
}
