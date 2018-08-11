using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingLine : MonoBehaviour
{

    public GameObject ring;
    public GameObject lineTile;
    public float scale;

    private List<GameObject> tiles;
    private Vector2 startPosition;
    private bool visible;

    void Start()
    {
        this.tiles = new List<GameObject>();
        this.startPosition = ring.transform.position;
    }

    void Update()
    {
        if (!this.visible)
        {
            return;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lineVector = mousePos - ring.transform.position;

        while (lineVector.magnitude > (tiles.Count + 1.5) * scale)
        {
            GameObject instance = Instantiate(lineTile, startPosition + lineVector * 0.5f, Quaternion.identity);
            tiles.Add(instance);
        }

        while (lineVector.magnitude < (tiles.Count + 0.5) * scale)
        {
            GameObject toDelete = tiles[tiles.Count - 1];
            tiles.Remove(toDelete);
            GameObject.Destroy(toDelete);
        }

        for (int i = 0; i < tiles.Count; i++)
        {
            tiles[i].transform.rotation = Quaternion.LookRotation(Vector3.forward, lineVector);
            tiles[i].transform.position = startPosition + (lineVector.normalized * scale) * (i+1);
        }
    }

    public void SetVisible(bool visible)
    {
        this.visible = visible;
        foreach (GameObject tile in this.tiles)
        {
            tile.SetActive(visible);
        }
    }
}