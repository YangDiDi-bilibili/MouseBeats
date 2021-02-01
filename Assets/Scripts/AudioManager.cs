using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SetPlaySpeed(float speed)
    {
        audioSource.pitch = speed;
    }
}
