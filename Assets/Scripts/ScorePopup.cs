using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePopup : MonoBehaviour {

	public NumberDisplay display;

	public void SetScore(int score)
	{
		this.display.SetNumber("+" + score);
	}

	void DestroySelf()
	{
		GameObject.Destroy(this.gameObject);
	}
}
