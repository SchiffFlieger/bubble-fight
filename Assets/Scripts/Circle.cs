using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {

	public int maxHits;
	public NumberDisplay display;

	private int hits;

	void Start() 
	{
		this.hits = Random.Range(1, maxHits);
		display.SetNumber(hits);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ring"))
		{
			this.hits--;
			UpdateCircle();
		}
	}

	private void UpdateCircle()
	{
		if (this.hits <= 0)
		{
			GameObject.Destroy(this.gameObject);
			GameObject.Destroy(this.display.gameObject);
		}
		this.display.SetNumber(this.hits);
	}
}
