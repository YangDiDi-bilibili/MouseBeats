using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [Header("音符")]
    public List<GameObject> tapLeft = new List<GameObject>();
    public List<GameObject> tapRight = new List<GameObject>();

    [Header("特效")]
    public List<GameObject> perfect = new List<GameObject>();
    public List<GameObject> good = new List<GameObject>();

    public static GameObjectPool instance;

    private void Awake()
    {
        instance = this;
        SetActive(false);
    }

    private void SetActive(bool tmp)
    {
        foreach (var item in tapLeft)
        {
            item.SetActive(tmp);
        }

    }


}
