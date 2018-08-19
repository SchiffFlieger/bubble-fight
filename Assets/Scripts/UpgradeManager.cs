using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public float countUpgradePossibility;
    public float damageUpgradePossibility;
    public SpawnAnimation countUpgradeSpawnPrefab;
    public SpawnAnimation damageUpgradeSpawnPrefab;

    private int ringCount = 1;
    private int ringDamage = 1;

    public void UpdateRefreshState()
    {

    }

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

    private void DeleteOnCollision(GameObject upgrade, GameObject[] circles)
    {
        foreach(GameObject circle in circles)
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
        Instantiate(countUpgradeSpawnPrefab, position, Quaternion.identity);
    }

    void SpawnDamageUpgrade(Vector3 position)
    {
        Instantiate(damageUpgradeSpawnPrefab, position, Quaternion.identity);
    }

    public void PickedUpCountUpgrade()
    {
        this.ringCount++;
        ScoreManager.AddRing();
    }

    public void PickedUpDamageUpgrade()
    {
        this.ringDamage++;
        ScoreManager.AddDamage();
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
