using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioPrefab")]
public class AudioPrefab : ScriptableObject
{
    public string audioName;
    public AudioClip audioClip;
}
