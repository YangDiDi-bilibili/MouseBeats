using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCombo : MonoBehaviour
{
    public enum Type
    {
        Combo,
        Perfect,
        Good,
        Bad,
        Miss,
        Determined
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
            case Type.Perfect:
                text.text = "Perfect: " + ScoreManager.perfectCount.ToString();
                break;
            case Type.Good:
                text.text = ScoreManager.goodCount.ToString();
                break;
            case Type.Bad:
                text.text = ScoreManager.badCount.ToString();
                break;
            case Type.Miss:
                text.text = ScoreManager.missCount.ToString();
                break;
            case Type.Determined:
                text.text = ScoreManager.determined.ToString();
                break;
            default:
                break;
        }
    }
}
