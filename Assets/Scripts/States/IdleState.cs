using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private ShootingLine shootingLine;
    private StateManager stateManager;
    private Ring staticRing;

    public IdleState(StateManager stateManager, ShootingLine shootingLine, Ring staticRing)
    {
        this.stateManager = stateManager;
        this.shootingLine = shootingLine;
        this.staticRing = staticRing;
    }

    public void Enter()
    {
        this.shootingLine.SetVisible(true);
        this.staticRing.gameObject.SetActive(true);
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
}
