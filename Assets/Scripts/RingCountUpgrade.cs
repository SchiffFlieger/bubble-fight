﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingCountUpgrade : MonoBehaviour
{

    public StateManager circleManager;
    public float rotationSpeed;
    public int despawnAfterRounds;

    private int activeRounds;

    void Update()
    {
        this.transform.Rotate(Vector3.forward * rotationSpeed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ring"))
        {
            this.circleManager.ringsToShoot++;
            GameObject.Destroy(this.gameObject);
        }
    }

    public void NextRound()
    {
        activeRounds++;
    }

    public bool ShouldDespawn()
    {
        return activeRounds >= despawnAfterRounds;
    }
}
