using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodDetect : MonoBehaviour
{
    public List<GameObject> goodNotes = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            goodNotes.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            goodNotes.Remove(collision.gameObject);
            collision.GetComponentInParent<NotesGenerate>().ReturnGameObject();
        }
    }
}
