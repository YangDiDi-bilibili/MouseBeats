using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectDetect : MonoBehaviour
{
    public static Queue<GameObject> perfectNotes = new Queue<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            perfectNotes.Enqueue(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (perfectNotes.Peek() == collision.gameObject)
            {
                perfectNotes.Dequeue();
            }
            else
            {
                Debug.LogError(collision.gameObject + "不是perfect队列的首位");
            }
        }
    }

    public static GameObject GetPerfectPeek()
    {
        return perfectNotes.Peek();
    }
}
