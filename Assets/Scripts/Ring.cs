using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public int damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bottom"))
        {
            Destroy(this.gameObject);
        }
    }
}
