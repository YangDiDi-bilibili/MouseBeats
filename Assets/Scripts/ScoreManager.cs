using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public enum Determined
    {
        perfect,
        good,
        bad,
        miss
    }

    public static Determined determined;

    public static int score;
    public static int perfectCount;
    public static int goodCount;
    public static int badCount;
    public static int missCount;
    public static int combo;
    public static int maxCombo;

    private void Start()
    {
        score = 0;
        perfectCount = 0;
        goodCount = 0;
        badCount = 0;
        missCount = 0;
        combo = 0;
    }

    public static void Perfect()
    {
        perfectCount++;
        combo++;
        SetMaxCombo();
        determined = Determined.perfect;
        Debug.Log("Perfect!");
    }

    public static void Good()
    {
        goodCount++;
        combo++;
        SetMaxCombo();
        determined = Determined.good;
        Debug.Log("Good!");
    }

    public static void Bad()
    {
        badCount++;
        combo = 0;
        determined = Determined.bad;
        Debug.Log("Bad!");
    }

    public static void Miss()
    {
        missCount++;
        combo = 0;
        determined = Determined.miss;
        Debug.Log("Miss!");
    }

    private static void SetMaxCombo()
    {
        if (combo > maxCombo)
        {
            maxCombo = combo;
        }
    }
}
