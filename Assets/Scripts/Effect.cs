using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Disable", 2.0f);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
