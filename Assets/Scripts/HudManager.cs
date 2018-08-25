using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

	public Text ringCountText;
	public Text ringDamageText;
	public Text scoreText;

	private UpgradeManager upgradeManager;
	private StateManager stateManager;

	void Start () {
		this.upgradeManager = GameObject.FindObjectOfType<UpgradeManager>();	
		this.stateManager = GameObject.FindObjectOfType<StateManager>();	
	}
	
	void Update () {
		this.ringCountText.text = "Rings: " + this.stateManager.RingCount();
		this.ringDamageText.text = "Damage: " + this.upgradeManager.RingDamage().ToString();
		this.scoreText.text = "" + ScoreManager.GetScore().ToString();
	}
}
