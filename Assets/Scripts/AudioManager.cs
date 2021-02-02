﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    public void SetPlaySpeed(float speed)
    {
        audioSource.pitch = speed;
    }
}
