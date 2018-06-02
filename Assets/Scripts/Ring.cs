using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    void OnDestroy() 
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bottom"))
        {
            Destroy(this.gameObject);
        }
    }
}
