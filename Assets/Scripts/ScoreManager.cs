using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private int score;
    void Start()
    {
        this.score = 0;
    }

    public void CircleHit()
    {
        score++;
    }

    public void CircleDestroyed()
    {
        score += 5;
    }

    public int GetScore()
    {
        return score;
    }
}
