using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningState : IState
{
    private int spawnPauseDuration = 10; // find a better place for this

    private int spawnTimer;
    private int ringsShot;
    private int ringsToShoot;
    private Vector2 direction;

    private StateManager stateManager;
    private UpgradeManager upgradeManager;
    private ShootingLine shootingLine;
    private Ring ringPrefab;
    private Ring staticRing;

    public SpawningState(StateManager stateManager, UpgradeManager upgradeManager, ShootingLine shootingLine, Ring ringPrefab, Ring staticRing)
    {
        this.stateManager = stateManager;
        this.upgradeManager = upgradeManager;
        this.shootingLine = shootingLine;
        this.ringPrefab = ringPrefab;
        this.staticRing = staticRing;
    }

    public void Enter()
    {
        this.shootingLine.SetVisible(false);
        this.ringsShot = 0;
    }

    public void Update()
    {
        if (this.spawnTimer >= this.spawnPauseDuration)
        {
            this.staticRing.gameObject.SetActive(false);
            Ring instance = GameObject.Instantiate(this.ringPrefab, this.ringPrefab.transform.position, Quaternion.identity);
            instance.Shoot(direction);

            this.ringsShot++;
            this.spawnTimer = 0;
        }

        this.spawnTimer++;
    }

    public IState NextState()
    {
        if (this.ringsShot >= this.upgradeManager.RingCount())
        {
            return this.stateManager.flyingState;
        }

        return this;
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}
