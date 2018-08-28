using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public float rotationSpeed;
    public string type;

    private UpgradeManager upgradeManager;
    private PolygonCollider2D polygonCollider;
    private AudioSource pickupSound;

    void Start()
    {
        this.gameObject.transform.localScale = new Vector3(0, 0, 0);
        this.upgradeManager = GameObject.FindObjectOfType<UpgradeManager>();
        this.polygonCollider = GetComponent<PolygonCollider2D>();
        this.pickupSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        this.transform.Rotate(Vector3.forward * rotationSpeed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ring"))
        {
            AudioSource.PlayClipAtPoint(pickupSound.clip, this.transform.position);
            GameObject.Destroy(this.gameObject);
            this.upgradeManager.PickedUpUpgrade(type);
            this.polygonCollider.enabled = false;
        }
    }

    private void DestroySelf()
    {
        GameObject.Destroy(this.gameObject);
    }
}
