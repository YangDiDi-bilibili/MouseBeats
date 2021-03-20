using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCombo : MonoBehaviour
{
    public enum Type
    {
        Combo,
        Determined,
        Perfect,
        Good,
        Bad,
        Miss,
        maxCombo,
        NotesCount
    }

    Text text;
    public Type type;

    private void OnEnable()
    {
        text = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        switch (type)
        {
            case Type.Combo:
                text.text = "Combo: " + ScoreManager.combo.ToString();
                break;
            case Type.Determined:
                text.text = ScoreManager.determined.ToString();
                break;
            case Type.Perfect:
                text.text = "Perfect: " + ScoreManager.perfectCount.ToString();
                break;
            case Type.Good:
                text.text = "Good: " + ScoreManager.goodCount.ToString();
                break;
            case Type.Bad:
                text.text = "Bad: " + ScoreManager.badCount.ToString();
                break;
            case Type.Miss:
                text.text = "Miss: " + ScoreManager.missCount.ToString();
                break;
            case Type.maxCombo:
                text.text = "MaxCombo: " + ScoreManager.maxCombo.ToString();
                break;
            case Type.NotesCount:
                text.text = "NotesCount: " + ScoreManager.notesCount.ToString();
                break;
            default:
                break;
        }
    }
}
