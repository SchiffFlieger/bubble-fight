using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

	public Text ringCountText;
	public Text ringDamageText;
	public Text scoreText;

	private ScoreManager scoreManager;
	private UpgradeManager upgradeManager;


	void Start () {
        this.scoreManager = GameObject.FindObjectOfType<ScoreManager>();	
		this.upgradeManager = GameObject.FindObjectOfType<UpgradeManager>();	
	}
	
	void Update () {
		this.ringCountText.text = "Rings: " + this.upgradeManager.RingCount().ToString();
		this.ringDamageText.text = "Damage: " + this.upgradeManager.RingDamage().ToString();
		this.scoreText.text = "Score: " + scoreManager.GetScore().ToString();
	}
}
