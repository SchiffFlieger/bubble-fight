using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public NumberDisplay display;

    private int hitsLeft;
    private UpgradeManager upgradeManager;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private CircleCollider2D circleCollider;
    private AudioSource deathSound;


    void Start()
    {
        this.upgradeManager = GameObject.FindObjectOfType<UpgradeManager>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.animator = GetComponent<Animator>();
        this.circleCollider = GetComponent<CircleCollider2D>();
        this.deathSound = GetComponent<AudioSource>();

        int max = (int)((upgradeManager.RingCount() * upgradeManager.RingDamage()) * 1.5f) + 3;
        int min = (int)Mathf.Clamp(max * 0.7f - 1, 1.0f, max);
        this.hitsLeft = Random.Range(min, max);

        display.SetNumber("" + hitsLeft);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            this.hitsLeft = Mathf.Clamp(hitsLeft - upgradeManager.RingDamage(), 0, hitsLeft - upgradeManager.RingDamage());
            StaticWriter.damageDone += this.upgradeManager.RingDamage();
            ScoreManager.AddTotalDamage(this.upgradeManager.RingDamage());
            UpdateCircle();
        }
    }

    private void UpdateCircle()
    {
        if (this.hitsLeft <= 0)
        {
            animator.SetTrigger("destroyed");
            AudioSource.PlayClipAtPoint(this.deathSound.clip, this.transform.position);
            GameObject.Destroy(this.display.gameObject);
            circleCollider.enabled = false;
        }
        this.display.SetNumber("" + this.hitsLeft);
    }

    private void DestroySelf()
    {
        ScoreManager.AddScore(7);
        ScoreManager.CircleDestroyed();
        GameObject.Destroy(this.gameObject);
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
