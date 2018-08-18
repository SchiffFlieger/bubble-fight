using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingDamageUpgrade : MonoBehaviour
{

    public float rotationSpeed;
    public DestroyAnimation destroyAnimationPrefab;

    private UpgradeManager upgradeManager;

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
            this.upgradeManager.PickedUpDamageUpgrade();
            GameObject.Instantiate(destroyAnimationPrefab, this.transform.position, this.transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }
}
