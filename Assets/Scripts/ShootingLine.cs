using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingLine : MonoBehaviour
{

    public GameObject ring;

    void Start()
    {
        LineRenderer line = GetComponent<LineRenderer>();

        line.positionCount = 2;
        line.startWidth = 0.15f;
        line.endWidth = 0.15f;
        line.useWorldSpace = true;

        line.SetPosition(0, ring.transform.position);
    }

    void Update()
    {
        LineRenderer line = GetComponent<LineRenderer>();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        line.SetPosition(1, mousePos);
    }
}