using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeListObject : MonoBehaviour
{
    public List<GameObject> awkeItems = new List<GameObject>();

    private void OnEnable()
    {
        foreach (var item in awkeItems)
        {
            item.SetActive(true);
        }
    }
}
