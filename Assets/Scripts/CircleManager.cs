using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour {

	enum State {
		Idle, RingSpawning, Shooting, Refreshing
	}

	public int shootsTillNextRow;

	private State state;
	private int shootsSinceLastRow;

	void Start () {
		this.state = State.Idle;		
		this.shootsSinceLastRow = 0;
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
		}
	}

	void UpdateIdle() 
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			this.state = State.RingSpawning;
		}
	}

	void UpdateRingSpawning()
	{
		// spawn a new ring every xx frames and apply velocity
		// if all rings are spawned, change state to shooting
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
