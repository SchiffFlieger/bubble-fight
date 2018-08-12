using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    enum State
    {
        Idle, Spawning, Flying, Refreshing
    }

    public int shotsTillNextRow;
    public int spawnPauseDuration;
    public int ringsToShoot;
    public int speed;
    public int ringDamage;

    public Ring staticRing;
    public Ring ringPrefab;
    public Circle circlePrefab;

    private State state;
    private int shotsSinceLastRow;
    private int spawnTimer;
    private int ringsShot;
    private Vector3 initialPosition;
    private Vector2 direction;
    private List<Circle> circles;
    private LevelManager levelManager;
    private UpgradeManager upgradeManager;
    private ShootingLine shootingLine;

    void Start()
    {
        this.state = State.Refreshing;
        this.shotsSinceLastRow = this.shotsTillNextRow;
        this.spawnTimer = this.spawnPauseDuration;
        this.ringsShot = 0;
        this.circles = new List<Circle>();

        this.initialPosition = staticRing.transform.position;
        this.levelManager = GameObject.FindObjectOfType<LevelManager>();
        this.upgradeManager = GameObject.FindObjectOfType<UpgradeManager>();
        this.shootingLine = GameObject.FindObjectOfType<ShootingLine>();
    }

    void Update()
    {
        Debug.Log(state);
        switch (state)
        {
            case State.Idle:
                UpdateIdle();
                break;
            case State.Spawning:
                UpdateSpawning();
                break;
            case State.Flying:
                UpdateFlying();
                break;
            case State.Refreshing:
                UpdateRefreshing();
                break;
            default:
                Debug.LogError("something strange happened");
                break;
        }
    }

    void UpdateIdle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            staticRing.gameObject.SetActive(false);
            this.direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.initialPosition;
            this.state = State.Spawning;
            this.shootingLine.SetVisible(false);
        }
    }

    void UpdateSpawning()
    {
        if (this.spawnTimer >= this.spawnPauseDuration)
        {
            Ring instance = Instantiate(ringPrefab, this.initialPosition, Quaternion.identity);
            instance.damage = this.ringDamage;
            instance.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
            this.ringsShot++;

            this.spawnTimer = 0;
            if (this.ringsShot >= this.ringsToShoot)
            {
                this.state = State.Flying;
            }
        }

        this.spawnTimer++;
    }

    void UpdateFlying()
    {
        if (GameObject.FindGameObjectsWithTag("Ring").Length <= 0)
        {
            this.state = State.Refreshing;
        }
    }

    void UpdateRefreshing()
    {
        if (this.shotsSinceLastRow >= this.shotsTillNextRow)
        {
            this.shotsSinceLastRow = 0;

            foreach (Circle circ in this.circles)
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

            AddCircle(-2.5f);
            AddCircle(-1.5f);
            AddCircle(-0.5f);
            AddCircle(0.5f);
            AddCircle(1.5f);
            AddCircle(2.5f);
        }

        this.upgradeManager.UpdateRefreshState();

        this.ringsShot = 0;
        this.shotsSinceLastRow++;
        this.staticRing.gameObject.SetActive(true);
        this.state = State.Idle;
        this.shootingLine.SetVisible(true);
    }

    void AddCircle(float x)
    {
        Circle instance = Instantiate(circlePrefab, new Vector3(x, 8.5f, -2.0f), Quaternion.identity);
        
        this.circles.Add(instance);
    }

}
