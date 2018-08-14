using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    private static int score, rings, damage, totalDamage, circlesDestroyed;

    public static void Reset()
    {
        ScoreManager.score = 0;
        ScoreManager.rings = 1;
        ScoreManager.damage = 1;
        ScoreManager.totalDamage = 0;
        ScoreManager.circlesDestroyed = 0;
    }

    public static void AddScore(int score)
    {
        ScoreManager.score += score;
    }

    public static int GetScore()
    {
        return ScoreManager.score;
    }

    public static void AddRing()
    {
        ScoreManager.rings++;
    }

    public static int GetRings()
    {
        return ScoreManager.rings;
    }

        public static void AddDamage()
    {
        ScoreManager.damage++;
    }

    public static int GetDamage()
    {
        return ScoreManager.damage;
    }

    public static void AddTotalDamage(int n)
    {
        ScoreManager.totalDamage += n;
    }

    public static int GetTotalDamage()
    {
        return ScoreManager.totalDamage;
    }

    public static void CircleDestroyed()
    {
        ScoreManager.circlesDestroyed++;
    }

    public static int GetCirclesDestroyed()
    {
        return ScoreManager.circlesDestroyed;
    }
}
