using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingState : IState
{
    private StateManager stateManager;

    public FlyingState(StateManager stateManager)
    {
        this.stateManager = stateManager;
    }

    public void Enter()
    {
    }

    public void Update()
    {
        
    }

    public IState NextState()
    {
        if (GameObject.FindGameObjectsWithTag("Ring").Length <= 0)
        {
            return stateManager.refreshingState ;
        }
        return this;
    }
}
