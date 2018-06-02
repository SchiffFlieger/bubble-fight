using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour {

	enum State {
		Idle, RingSpawning, Shooting, Refreshing
	}

	public int shootsTillNextRow;
	public int spawnTimerInFrames;
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

	void Start () {
		this.state = State.Idle;		
		this.shootsSinceLastRow = 0;
		this.spawnTimer = 0;
		this.ringsShot = 0;

		this.initialPosition = ring.transform.position;
	}
	
	void Update () {
		switch(state) {
			case State.Idle:
				UpdateIdle();
				break;
			case State.RingSpawning:
				UpdateRingSpawning();
				break;
			case State.Shooting:
				UpdateShooting();
				break;
			case State.Refreshing:
				UpdateRefreshing();
				break;
			default:
				print("something strange happened");
				break;
		}
	}

	void UpdateIdle() 
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			ring.gameObject.SetActive(false);
            this.direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
			this.state = State.RingSpawning;
		}

		this.ring.transform.position = this.initialPosition;
	}

	void UpdateRingSpawning()
	{
		if (this.spawnTimer >= this.spawnTimerInFrames)
		{
			Transform instance = Instantiate(prefab, this.initialPosition, Quaternion.identity);
            instance.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
			this.ringsShot++;

			this.spawnTimer = 0;
			if (this.ringsShot >= this.ringsToShoot)
			{
				this.state = State.Shooting;
			}
		}

		this.spawnTimer++;
	}
	
	void UpdateShooting()
	{
		// move rings
		// check if there are rings left
		// change state to refreshing if no rings left
	}

	void UpdateRefreshing()
	{
		// spawn new row if necessary
		// change state to idle
	}
}
