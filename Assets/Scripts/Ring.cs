using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public int speed;

    public void Shoot(Vector3 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bottom"))
        {
            Destroy(this.gameObject);
        }
    }
}
