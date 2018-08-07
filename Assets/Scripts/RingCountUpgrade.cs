using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingCountUpgrade : MonoBehaviour
{

    public CircleManager circleManager;
	public float rotationSpeed;

	void Update() {
		this.transform.Rotate(Vector3.forward * rotationSpeed);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ring"))
        {
            this.circleManager.ringsToShoot++;
            GameObject.Destroy(this.gameObject);
        }
    }
}
