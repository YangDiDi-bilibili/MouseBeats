using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Setting")]
public class Setting : ScriptableObject
{
    public bool doDebugMouse;
    public bool doDebugDetermined;
    [Range(1, 1)] public float timeScale = 1.0f;

    [Range(0, 1)] public float effectVolume;
}
