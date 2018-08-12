using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

	public Text ringCountText;
	public Text ringDamageText;
	public Text scoreText;

	private StateManager circleManager;
	private ScoreManager scoreManager;


	void Start () {
		this.circleManager = GameObject.FindObjectOfType<StateManager>();
        this.scoreManager = GameObject.FindObjectOfType<ScoreManager>();		
	}
	
	void Update () {
		this.ringCountText.text = "Rings: " + circleManager.ringsToShoot.ToString();
		this.ringDamageText.text = "Damage: " + circleManager.ringDamage.ToString();
		this.scoreText.text = "Score: " + scoreManager.GetScore().ToString();
	}
}
