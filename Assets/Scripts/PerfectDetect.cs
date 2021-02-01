using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectDetect : MonoBehaviour
{
    public List<GameObject> perfectNotes = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            perfectNotes.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            perfectNotes.Remove(collision.gameObject);
        }
    }
}
