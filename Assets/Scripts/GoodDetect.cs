using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NotesInfo;

public class GoodDetect : MonoBehaviour
{
    public static Queue<GameObject> goodNotesLeft = new Queue<GameObject>();
    public static Queue<GameObject> goodNotesRight = new Queue<GameObject>();

    private void Start()
    {
        goodNotesLeft.Clear();
        goodNotesRight.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (GetNoteDirection(collision.gameObject))
            {
                goodNotesLeft.Enqueue(collision.gameObject);
            }
            else
            {
                goodNotesRight.Enqueue(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (goodNotesLeft.Count != 0)
            {
                if (goodNotesLeft.Peek() == collision.gameObject)
                {
                    goodNotesLeft.Dequeue();
                }
            }
            else if (goodNotesRight.Count != 0)
            {
                if (goodNotesRight.Peek() == collision.gameObject)
                {
                    goodNotesRight.Dequeue();
                }
            }
            else
            {
                Debug.LogError(collision.gameObject + "不是good队列的首位");
            }
        }
    }
}
