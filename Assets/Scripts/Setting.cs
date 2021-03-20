using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Setting")]
public class Setting : ScriptableObject
{
    [Header("编辑器属性")]
    public bool doDebugMouse;
    public bool doDebugDetermined;
    public bool doDebugClear;
    public bool doDebugCount;
    public bool doDetermined;
    [Range(1, 1)] public float timeScale = 1.0f;

    [Header("游戏属性")]
    [Range(0, 1)] public float effectVolume;
}
