using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour
{

    enum State
    {
        Idle, Spawning, Flying, Refreshing
    }

    public int shotsTillNextRow;
    public int spawnPauseDuration;
    public int ringsToShoot;
    public int speed;
    public float upgradePossibility;

    public Ring ring;
    public Transform ringPrefab;
    public Transform circlePrefab;
    public RingCountUpgrade ringCountUpgradePrefab;

    private State state;
    private int shotsSinceLastRow;
    private int spawnTimer;
    private int ringsShot;
    private Vector3 initialPosition;
    private Vector2 direction;
    private List<Transform> circles;

    void Start()
    {
        this.state = State.Refreshing;
        this.shotsSinceLastRow = this.shotsTillNextRow;
        this.spawnTimer = this.spawnPauseDuration;
        this.ringsShot = 0;
        this.circles = new List<Transform>();

        this.initialPosition = ring.transform.position;
    }

    void Update()
    {
        print(state.ToString());
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
            ring.gameObject.SetActive(false);
            this.direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.initialPosition;
            this.state = State.Spawning;
        }

        this.ring.transform.position = this.initialPosition;
    }

    void UpdateSpawning()
    {
        if (this.spawnTimer >= this.spawnPauseDuration)
        {
            Transform instance = Instantiate(ringPrefab, this.initialPosition, Quaternion.identity);
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

            foreach (Transform circ in this.circles)
            {
                if (circ != null)
                {
                    circ.position = new Vector3(circ.position.x, circ.position.y - 1, circ.position.z);
                }
            }

            AddCircle(-2.5f);
            AddCircle(-1.5f);
            AddCircle(-0.5f);
            AddCircle(0.5f);
            AddCircle(1.5f);
            AddCircle(2.5f);
        }

        if (this.upgradePossibility > Random.Range(0.0f, 1.0f))
        {
            SpawnUpgrade();
        }

        this.ringsShot = 0;
        this.shotsSinceLastRow++;
        this.ring.gameObject.SetActive(true);
        this.state = State.Idle;
    }

    void AddCircle(float x)
    {
        Transform instance = Instantiate(circlePrefab, new Vector3(x, 8.5f, -2.0f), Quaternion.identity);
        this.circles.Add(instance);
    }

    void SpawnUpgrade()
    {
        RingCountUpgrade instance = Instantiate(ringCountUpgradePrefab, new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(2.0f, 8.0f), -2.0f), Quaternion.identity);
        instance.circleManager = this;
    }
}
