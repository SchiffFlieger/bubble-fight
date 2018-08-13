using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingCountUpgrade : MonoBehaviour
{
    private UpgradeManager upgradeManager;
    public float rotationSpeed;
    public int despawnAfterRounds;

    private int activeRounds;

    void Start()
    {
        this.upgradeManager = GameObject.FindObjectOfType<UpgradeManager>();
    }

    void Update()
    {
        this.transform.Rotate(Vector3.forward * rotationSpeed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ring"))
        {
            this.upgradeManager.PickedUpCountUpgrade();
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
