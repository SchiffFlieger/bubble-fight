using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingCountUpgrade : MonoBehaviour
{
    private UpgradeManager upgradeManager;
    public float rotationSpeed;
    public DestroyAnimation destroyAnimationPrefab;

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
            GameObject.Instantiate(destroyAnimationPrefab, this.transform.position, this.transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }
}
