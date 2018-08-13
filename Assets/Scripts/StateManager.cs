using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public Ring staticRing;
    public Ring ringPrefab;
    public Circle circlePrefab;

    private LevelManager levelManager;
    private UpgradeManager upgradeManager;
    private ShootingLine shootingLine;


    private IState currentState;
    private IState nextState;
    public IdleState idleState;
    public SpawningState spawningState;
    public FlyingState flyingState;
    public RefreshingState refreshingState;

    void Start()
    {
        this.levelManager = GameObject.FindObjectOfType<LevelManager>();
        this.upgradeManager = GameObject.FindObjectOfType<UpgradeManager>();
        this.shootingLine = GameObject.FindObjectOfType<ShootingLine>();

        this.idleState = new IdleState(this, shootingLine, staticRing);
        this.spawningState = new SpawningState(this, upgradeManager, shootingLine, ringPrefab, staticRing);
        this.flyingState = new FlyingState(this);
        this.refreshingState = new RefreshingState(this, levelManager, upgradeManager, circlePrefab);

        this.currentState = this.refreshingState;
        this.nextState = this.refreshingState;
    }

    void Update()
    {
        if (!Object.ReferenceEquals(this.currentState, this.nextState))
        {
            this.nextState.Enter();
            this.currentState = this.nextState;
        }
        this.currentState.Update();
        this.nextState = this.currentState.NextState();
    }
}
