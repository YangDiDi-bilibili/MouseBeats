﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NotesInfo;

public class PerfectDetect : MonoBehaviour
{
    public static Queue<GameObject> perfectNotesLeft = new Queue<GameObject>();
    public static Queue<GameObject> perfectNotesRight = new Queue<GameObject>();

    private void Start()
    {
        perfectNotesLeft.Clear();
        perfectNotesRight.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (GetNoteDirection(collision.gameObject))
            {
                perfectNotesLeft.Enqueue(collision.gameObject);
            }
            else
            {
                perfectNotesRight.Enqueue(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (perfectNotesLeft.Count != 0)
            {
                if (perfectNotesLeft.Peek() == collision.gameObject)
                {
                    perfectNotesLeft.Dequeue();
                }

            }
            else if (perfectNotesRight.Count != 0)
            {
                if (perfectNotesRight.Peek() == collision.gameObject)
                {
                    perfectNotesRight.Dequeue();
                }
            }
            else
            {
                Debug.LogError(collision.gameObject + "不是perfect队列的首位");
            }

            if (collision.gameObject.activeSelf)
            {
                if (GetNoteType(collision.gameObject)==3)
                {
                    ScoreManager.Miss();
                    collision.gameObject.GetComponentInParent<NotesGenerate>().ReturnGameObject();
                }
            }

        }
    }
}
