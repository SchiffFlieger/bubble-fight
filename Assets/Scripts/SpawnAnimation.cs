using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimation : MonoBehaviour {

	public int framesPerState;
	public Sprite[] sprites;
	public GameObject prefab;

	private int currentSprite;
	private int currentFrame;
	private SpriteRenderer spriteRenderer;

	void Start () {
		this.currentSprite = 0;
		this.currentFrame = 0;
		this.spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
		currentFrame++;
		if (currentFrame > currentSprite * framesPerState)
		{
			currentSprite++;
			if (currentSprite >= sprites.Length)
			{
				Instantiate(prefab, transform.position, Quaternion.identity);
				Destroy(this.gameObject);
				return;
			}
			spriteRenderer.sprite = sprites[currentSprite];
		}		
	}
}
