using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour
{

    enum State
    {
        Idle, Spawning, Flying, Refreshing
    }

    public int shootsTillNextRow;
    public int spawnPauseDuration;
    public int ringsToShoot;
    public int speed;

    public Ring ring;
    public Transform prefab;

    private State state;
    private int shootsSinceLastRow;
    private int spawnTimer;
    private int ringsShot;
    private Vector3 initialPosition;
    private Vector2 direction;

    void Start()
    {
        this.state = State.Idle;
        this.shootsSinceLastRow = 0;
        this.spawnTimer = this.spawnPauseDuration;
        this.ringsShot = 0;

        this.initialPosition = ring.transform.position;
    }

    void Update()
    {
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
		print("idle");
        if (Input.GetMouseButtonDown(0))
        {
            ring.gameObject.SetActive(false);
            this.direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
            this.state = State.Spawning;
        }

        this.ring.transform.position = this.initialPosition;
    }

    void UpdateSpawning()
    {		
		print("spawning");
        if (this.spawnTimer >= this.spawnPauseDuration)
        {
            Transform instance = Instantiate(prefab, this.initialPosition, Quaternion.identity);
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
		print("flying");	
        // move rings
        // check if there are rings left
        // change state to refreshing if no rings left
    }

    void UpdateRefreshing()
    {
		print("refreshing");
        // spawn new row if necessary
        // change state to idle
    }
}
