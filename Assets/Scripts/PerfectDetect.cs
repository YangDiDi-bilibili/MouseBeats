using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectDetect : MonoBehaviour
{
    public static Queue<GameObject> perfectNotesLeft = new Queue<GameObject>();
    public static Queue<GameObject> perfectNotesRight = new Queue<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (DetectLine.GetNoteDirection(collision.gameObject))
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
            if (DetectLine.GetNoteDirection(collision.gameObject))
            {
                if (perfectNotesLeft.Peek() == collision.gameObject)
                {
                    perfectNotesLeft.Dequeue();
                }
                else
                {
                    Debug.LogError(collision.gameObject + "不是perfectLeft队列的首位");
                }
            }
            else
            {
                if (perfectNotesRight.Peek() == collision.gameObject)
                {
                    perfectNotesRight.Dequeue();
                }
                else
                {
                    Debug.LogError(collision.gameObject + "不是perfectRight队列的首位");
                }

            }
        }
    }
}
