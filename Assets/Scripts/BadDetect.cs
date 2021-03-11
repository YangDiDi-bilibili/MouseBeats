using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NotesInfo;

public class BadDetect : MonoBehaviour
{
    private int layer;

    public static Queue<GameObject> badNotesLeft = new Queue<GameObject>();
    public static Queue<GameObject> badNotesRight = new Queue<GameObject>();

    private void Start()
    {
        badNotesLeft.Clear();
        badNotesRight.Clear();

        layer = GetComponentInParent<DetectLine>().layer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note") && layer == collision.gameObject.GetComponent<NotesGenerate>().layer)
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
        if (collision.CompareTag("Note") && layer == collision.gameObject.GetComponent<NotesGenerate>().layer)
        {
            if (badNotesLeft.Count != 0)
            {
                if (badNotesLeft.Peek() == collision.gameObject)
                {
                    badNotesLeft.Dequeue();
                }
            }
            if (badNotesRight.Count != 0)
            {
                if (badNotesRight.Peek() == collision.gameObject)
                {
                    badNotesRight.Dequeue();
                }
            }

            if (collision.gameObject.GetComponent<NotesGenerate>().doEnabled)
            {
                ScoreManager.Miss();
                collision.gameObject.GetComponent<NotesGenerate>().ClearGameObject();
            }
        }
    }
}
