﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NotesInfo;

public class BadDetect : MonoBehaviour
{
    public static Queue<GameObject> badNotesLeft = new Queue<GameObject>();
    public static Queue<GameObject> badNotesRight = new Queue<GameObject>();

    private void Start()
    {
        badNotesLeft.Clear();
        badNotesRight.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (GetNoteDirection(collision.gameObject))
            {
                badNotesLeft.Enqueue(collision.gameObject);
            }
            else
            {
                badNotesRight.Enqueue(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //note离开bad collider，实现miss
        if (collision.CompareTag("Note"))
        {
            if (badNotesLeft.Peek() == collision.gameObject)
            {
                badNotesLeft.Dequeue();
            }
            else if (badNotesRight.Peek() == collision.gameObject)
            {
                badNotesRight.Dequeue();
            }
            else
            {
                Debug.LogError(collision.gameObject + "不是bad队列的首位");
            }

            if (collision.gameObject.activeSelf)
            {
                ScoreManager.Miss();
                collision.gameObject.GetComponentInParent<NotesGenerate>().ReturnGameObject();
            }

        }
    }
}
