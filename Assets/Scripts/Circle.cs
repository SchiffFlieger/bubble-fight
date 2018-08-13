using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public NumberDisplay display;

    private int hitsLeft;
    private ScoreManager scoreManager;
    private UpgradeManager upgradeManager;

    private SpriteRenderer spriteRenderer;


    void Start()
    {
        this.hitsLeft = Random.Range(1, 3);

        this.scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        this.upgradeManager = GameObject.FindObjectOfType<UpgradeManager>();
        display.SetNumber(hitsLeft);
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            this.hitsLeft -= this.upgradeManager.RingDamage();
            UpdateCircle();
        }
    }

    private void UpdateCircle()
    {
        if (this.hitsLeft <= 0)
        {
            DestroyCircle();
        }
        this.display.SetNumber(this.hitsLeft);
    }

    private void DestroyCircle()
    {
            scoreManager.AddScore(7);
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(this.display.gameObject);
            this.upgradeManager.CheckSpawnUpgrade(this.transform.position);
    }

    void Update()
    {
        float red = Mathf.Atan(this.hitsLeft / 10.0f) - Mathf.PI / 6.0f;
        float green = 100.0f / this.hitsLeft;

        this.spriteRenderer.color = new Color(red, green, 0, 1.0f);
    }

}
