using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{

    public Text scoreText;
    public Text finalRingsText;
    public Text finalDamageText;
    public Text totalDamageText;
    public Text circlesDestroyedText;

    void Start()
    {
		this.scoreText.text = "Score: " + ScoreManager.GetScore();
		this.finalRingsText.text = "Final Rings: " + ScoreManager.GetRings();
		this.finalDamageText.text = "Final Damage: " + ScoreManager.GetDamage();
		this.totalDamageText.text = "Total Damage: " + ScoreManager.GetTotalDamage();
		this.circlesDestroyedText.text = "Circles Destroyed: " + ScoreManager.GetCirclesDestroyed();
    }

}
