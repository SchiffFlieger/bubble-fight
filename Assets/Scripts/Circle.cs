using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public NumberDisplay display;

    private int hitsLeft;
    private UpgradeManager upgradeManager;

    private SpriteRenderer spriteRenderer;


    void Start()
    {
        this.upgradeManager = GameObject.FindObjectOfType<UpgradeManager>();

        int max = (int) ((upgradeManager.RingCount() * upgradeManager.RingDamage()) * 1.5f) + 3;
        int min = (int) Mathf.Clamp(max*0.7f-1, 1.0f, max);
        Debug.Log("max: " + max + ", min: " + min);
        this.hitsLeft = Random.Range(min, max);

        display.SetNumber(hitsLeft);
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            this.hitsLeft -= this.upgradeManager.RingDamage();
            StaticWriter.damageDone += this.upgradeManager.RingDamage();
            ScoreManager.AddTotalDamage(this.upgradeManager.RingDamage());
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
            ScoreManager.AddScore(7);
            ScoreManager.CircleDestroyed();
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

    // Todo delete after game balance tests
    public int GetHitsLeft()
    {
        return hitsLeft;
    }

}
