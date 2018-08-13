using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public float countUpgradePossibility;
    public float damageUpgradePossibility;
    public RingCountUpgrade ringCountUpgradePrefab;
    public RingDamageUpgrade ringDamageUpgradePrefab;

    private int ringCount = 1;
    private int ringDamage = 1;

    public void UpdateRefreshState()
    {
		foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("CountUpgrade"))
		{
            RingCountUpgrade upgrade = gameObj.GetComponent<RingCountUpgrade>();
			upgrade.NextRound();
            if (upgrade.ShouldDespawn()) 
            {
                GameObject.Destroy(upgrade.gameObject);
            }
		}
		
		foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("DamageUpgrade"))
		{
            RingDamageUpgrade upgrade = gameObj.GetComponent<RingDamageUpgrade>();
			upgrade.NextRound();
            if (upgrade.ShouldDespawn()) 
            {
                GameObject.Destroy(upgrade.gameObject);
            }
		}
    }

    public void CheckSpawnUpgrade(Vector3 position)
    {
        float rnd = UnityEngine.Random.Range(0.0f, 1.0f);
        if (this.countUpgradePossibility > rnd) {
            SpawnCountUpgrade(position);
        } else if (this.damageUpgradePossibility + this.countUpgradePossibility > rnd)
        {
            SpawnDamageUpgrade(position);
        }
    }

    void SpawnCountUpgrade(Vector3 position)
    {
        Instantiate(ringCountUpgradePrefab, position, Quaternion.identity);
    }

    void SpawnDamageUpgrade(Vector3 position)
    {
        Instantiate(ringDamageUpgradePrefab, position, Quaternion.identity);
    }

    public void PickedUpCountUpgrade()
    {
        this.ringCount++;
    }

    public void PickedUpDamageUpgrade()
    {
        this.ringDamage++;
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
