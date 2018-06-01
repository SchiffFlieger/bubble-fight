using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {

	public int hits;

	private TextMesh text;

	void Start() 
	{
		this.text = this.transform.Find("Number").GetComponent<TextMesh>();
		UpdateCircle();	
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
		}
		this.text.text = "" + this.hits;
	}
}
