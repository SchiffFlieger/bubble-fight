using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {

	public int maxHits;
	public NumberDisplay display;

	private int hits;
    private ScoreManager scoreManager;
	private UpgradeManager upgradeManager;

	void Start() 
	{
		this.hits = Random.Range(1, maxHits);
		
        this.scoreManager = GameObject.FindObjectOfType<ScoreManager>();
		this.upgradeManager = GameObject.FindObjectOfType<UpgradeManager>();
		display.SetNumber(hits);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ring"))
		{
			this.hits -= this.upgradeManager.RingDamage();
			UpdateCircle();
		}
	}

	private void UpdateCircle()
	{
		if (this.hits <= 0)
		{
			scoreManager.AddScore(this.maxHits);
			GameObject.Destroy(this.gameObject);
			GameObject.Destroy(this.display.gameObject);
		}
		this.display.SetNumber(this.hits);
	}
}
