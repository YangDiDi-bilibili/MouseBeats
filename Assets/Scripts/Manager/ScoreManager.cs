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

    public static int notesCount;

    private void OnEnable()
    {
        GameManager.instance.OnResetValue += ScoreManager_ResetValue;
    }

    private void OnDisable()
    {
        GameManager.instance.OnResetValue -= ScoreManager_ResetValue;
    }

    private void ScoreManager_ResetValue()
    {
        score = 0;
        perfectCount = 0;
        goodCount = 0;
        badCount = 0;
        missCount = 0;
        notesCount = 0;
        combo = 0;
    }

    private void Start()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Note"))
        {
            notesCount++;
            item.SetActive(false);
        }

        if (GameManager.instance.setting.doDebugCount)
            Debug.Log("总共有" + notesCount + "个notes");

    }

    public static void Perfect()
    {
        perfectCount++;
        combo++;
        SetMaxCombo();
        determined = Determined.perfect;
        DebugDeterMined("Perfect!");
    }

    public static void Good()
    {
        goodCount++;
        combo++;
        SetMaxCombo();
        determined = Determined.good;
        DebugDeterMined("Good!");
    }

    public static void Bad()
    {
        badCount++;
        combo = 0;
        determined = Determined.bad;
        DebugDeterMined("Bad!");
    }

    public static void Miss()
    {
        missCount++;
        combo = 0;
        determined = Determined.miss;
        DebugDeterMined("Miss!");
    }

    private static void SetMaxCombo()
    {
        if (combo > maxCombo)
        {
            maxCombo = combo;
        }
    }

    private static void DebugDeterMined(string message)
    {
        if (GameManager.instance.setting.doDebugDetermined)
        {
            Debug.Log(message);
        }
    }
}
