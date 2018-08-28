using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public int speed;
    private AudioSource hitSound;

    void Start()
    {
        this.hitSound = GetComponent<AudioSource>();
    }

    public void Shoot(Vector3 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        this.hitSound.volume = collision.relativeVelocity.magnitude / 40.0f;
        this.hitSound.Play();
        if (collision.collider.CompareTag("Bottom"))
        {
            Destroy(this.gameObject);
        }
    }
}
