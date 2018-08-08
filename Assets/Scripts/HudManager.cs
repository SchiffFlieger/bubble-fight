using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

	public Text ringCountText;
	public Text ringDamageText;
	public Text scoreText;

	private CircleManager circleManager;
	private int dummyScore;


	void Start () {
		this.circleManager = GameObject.FindObjectOfType<CircleManager>();		
		this.dummyScore = 0;
	}
	
	void Update () {
		dummyScore++;
		this.ringCountText.text = "Rings: " + circleManager.ringsToShoot.ToString();
		this.ringDamageText.text = "Damage: " + circleManager.ringDamage.ToString();
		this.scoreText.text = "Score: " + dummyScore.ToString();
	}
}
