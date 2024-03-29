﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public float countUpgradePossibility;
    public float damageUpgradePossibility;
    public Upgrade countUpgradePrefab;
    public Upgrade damageUpgradePrefab;

    private int ringCount = 1;
    private int ringDamage = 1;

    public void CirclesMoved()
    {
        var circles = GameObject.FindGameObjectsWithTag("Circle");

        foreach (GameObject upgrade in GameObject.FindGameObjectsWithTag("CountUpgrade"))
        {
            DeleteOnCollision(upgrade, circles);
        }

        foreach (GameObject upgrade in GameObject.FindGameObjectsWithTag("DamageUpgrade"))
        {
            DeleteOnCollision(upgrade, circles);
        }

    }

    internal void PickedUpUpgrade(string type)
    {
        if (type.Equals("Count"))
        {
            this.ringCount++;
            ScoreManager.AddRing();
        }
        else if (type.Equals("Damage"))
        {
            this.ringDamage++;
            ScoreManager.AddDamage();
        }
        else
        {
            Debug.LogWarning("you picked up an undefined upgrade");
        }
    }

    private void DeleteOnCollision(GameObject upgrade, GameObject[] circles)
    {
        foreach (GameObject circle in circles)
        {
            if (upgrade.transform.position.Equals(circle.transform.position))
            {
                Destroy(upgrade.gameObject);
                return;
            }
        }
    }

    public void CheckSpawnUpgrade(Vector3 position)
    {
        float rnd = UnityEngine.Random.Range(0.0f, 1.0f);
        if (this.countUpgradePossibility > rnd)
        {
            SpawnCountUpgrade(position);
        }
        else if (this.damageUpgradePossibility + this.countUpgradePossibility > rnd)
        {
            SpawnDamageUpgrade(position);
        }
    }

    void SpawnCountUpgrade(Vector3 position)
    {
        Instantiate(countUpgradePrefab, position, Quaternion.identity);
    }

    void SpawnDamageUpgrade(Vector3 position)
    {
        Instantiate(damageUpgradePrefab, position, Quaternion.identity);
    }



    public int RingCount()
    {
        return ringCount;
    }

    public int RingDamage()
    {
        return ringDamage;
    }
}
