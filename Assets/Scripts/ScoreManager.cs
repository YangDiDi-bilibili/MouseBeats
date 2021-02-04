using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static int perfectCount;
    public static int goodCount;
    public static int missCount;

    public static void Perfect()
    {
        Debug.Log("Perfect!");
    }

    public static void Good()
    {
        Debug.Log("Good!");
    }

    public static void Bad()
    {
        Debug.Log("Bad!");
    }

    public static void Miss()
    {
        Debug.Log("Miss!");
    }
}
