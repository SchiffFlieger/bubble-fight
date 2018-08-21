using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public float rotationSpeed;
    public string type;

    private UpgradeManager upgradeManager;
    private Animator animator;
    private PolygonCollider2D polygonCollider;

    void Start()
    {
        this.upgradeManager = GameObject.FindObjectOfType<UpgradeManager>();
        this.animator = GetComponent<Animator>();
        this.polygonCollider = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        this.transform.Rotate(Vector3.forward * rotationSpeed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ring"))
        {
            animator.SetTrigger("destroyed");
            this.upgradeManager.PickedUpUpgrade(type);
            this.polygonCollider.enabled = false;
        }
    }

    private void DestroySelf()
    {
        GameObject.Destroy(this.gameObject);
    }
}
