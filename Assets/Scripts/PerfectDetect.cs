using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NotesInfo;

public class PerfectDetect : MonoBehaviour
{
    private int layer;

    public static Queue<GameObject> perfectNotesLeft = new Queue<GameObject>();
    public static Queue<GameObject> perfectNotesRight = new Queue<GameObject>();

    private void Start()
    {
        perfectNotesLeft.Clear();
        perfectNotesRight.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note") && layer == collision.gameObject.GetComponent<NotesGenerate>().layer)
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
        if (collision.CompareTag("Note") && layer == collision.gameObject.GetComponent<NotesGenerate>().layer)
        {
            if (perfectNotesLeft.Count != 0)
            {
                if (perfectNotesLeft.Peek() == collision.gameObject)
                {
                    perfectNotesLeft.Dequeue();
                }

            }
            if (perfectNotesRight.Count != 0)
            {
                if (perfectNotesRight.Peek() == collision.gameObject)
                {
                    perfectNotesRight.Dequeue();
                }
            }

            if (collision.gameObject.GetComponent<NotesGenerate>().doEnabled)
            {
                if (GetNoteType(collision.gameObject)==3)
                {
                    ScoreManager.Miss();
                    collision.gameObject.GetComponent<NotesGenerate>().ClearGameObject();
                }
            }

        }
    }
}
