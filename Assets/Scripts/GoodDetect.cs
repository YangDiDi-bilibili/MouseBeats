﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodDetect : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
        }
    }
}