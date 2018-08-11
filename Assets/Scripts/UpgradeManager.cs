using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public float countUpgradePossibility;
    public float damageUpgradePossibility;
    public RingCountUpgrade ringCountUpgradePrefab;
    public RingDamageUpgrade ringDamageUpgradePrefab;

    private CircleManager circleManager;
	private List<RingCountUpgrade> ringCountUpgrades;
	private List<RingDamageUpgrade> ringDamageUpgrades;

    void Start()
    {
        this.circleManager = GameObject.FindObjectOfType<CircleManager>();
		this.ringCountUpgrades = new List<RingCountUpgrade>();
		this.ringDamageUpgrades = new List<RingDamageUpgrade>();
    }

    public void UpdateRefreshState()
    {
		foreach (RingCountUpgrade upgrade in this.ringCountUpgrades)
		{
			upgrade.NextRound();
            if (upgrade.ShouldDespawn()) 
            {
                this.ringCountUpgrades.Remove(upgrade);
                GameObject.Destroy(upgrade.gameObject);
            }
		}
		
		foreach (RingDamageUpgrade upgrade in this.ringDamageUpgrades)
		{
			upgrade.NextRound();
            if (upgrade.ShouldDespawn()) 
            {
                this.ringDamageUpgrades.Remove(upgrade);
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
        instance.circleManager = this.circleManager;
		this.ringCountUpgrades.Add(instance);
    }

    void SpawnDamageUpgrade()
    {
        RingDamageUpgrade instance = Instantiate(ringDamageUpgradePrefab, new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(2.0f, 8.0f), -2.0f), Quaternion.identity);
        instance.circleManager = this.circleManager;
		this.ringDamageUpgrades.Add(instance);
    }
}
