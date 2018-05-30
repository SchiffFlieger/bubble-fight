using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{

    public int speed;

private bool active;
private Vector3 initialPos;
    // Use this for initialization
    void Start()
    {
        active = false;
        initialPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            active = true;
            Rigidbody2D body = GetComponent<Rigidbody2D>();
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
            body.velocity = direction.normalized * speed;
        }

        if (!active) 
        {
            this.transform.position = initialPos;
        }
    }

}
