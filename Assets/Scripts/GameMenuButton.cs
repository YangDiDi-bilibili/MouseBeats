﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuButton : MonoBehaviour
{
    public void PauseOnClick()
    {
        GameManager.instance.PauseGame();
    }
}