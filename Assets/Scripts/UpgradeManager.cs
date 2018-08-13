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

        if (this.countUpgradePossibility > Random.Range(0.0f, 1.0f))
        {
            SpawnCountUpgrade();
        }

        if (this.damageUpgradePossibility > Random.Range(0.0f, 1.0f))
        {
            SpawnDamageUpgrade();
        }
    }

    void SpawnCountUpgrade()
    {
        RingCountUpgrade instance = Instantiate(ringCountUpgradePrefab, new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(2.0f, 8.0f), -2.0f), Quaternion.identity);
    }

    void SpawnDamageUpgrade()
    {
        RingDamageUpgrade instance = Instantiate(ringDamageUpgradePrefab, new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(2.0f, 8.0f), -2.0f), Quaternion.identity);
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
