using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NotesInfo;

public class GoodDetect : MonoBehaviour
{
    private int layer;

    public static Queue<GameObject> goodNotesLeft = new Queue<GameObject>();
    public static Queue<GameObject> goodNotesRight = new Queue<GameObject>();

    private void Start()
    {
        goodNotesLeft.Clear();
        goodNotesRight.Clear();

        layer = GetComponentInParent<DetectLine>().layer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note") && layer == collision.gameObject.GetComponent<NotesGenerate>().layer)
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
        if (collision.CompareTag("Note") && layer == collision.gameObject.GetComponent<NotesGenerate>().layer)
        {
            if (goodNotesLeft.Count != 0)
            {
                if (goodNotesLeft.Peek() == collision.gameObject)
                {
                    goodNotesLeft.Dequeue();
                }
            }
            if (goodNotesRight.Count != 0)
            {
                if (goodNotesRight.Peek() == collision.gameObject)
                {
                    goodNotesRight.Dequeue();
                }
            }
        }
    }
}
