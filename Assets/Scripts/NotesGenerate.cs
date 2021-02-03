using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesGenerate : MonoBehaviour
{
    private GameObject note;

    public enum NoteType
    {
        leftTap,
        rightTap,
        leftHold,
        rightHold,
        leftFlick,
        rightFlick,
        leftDrag,
        rightDrag
    }

    public NoteType noteType;

    public static Queue<GameObject> notes = new Queue<GameObject>();

    private void OnEnable()
    {
        note = GameObjectPool.instance.GetNote(noteType);
        note.transform.position = gameObject.transform.position;
        note.transform.parent = gameObject.transform;

        notes.Enqueue(note);
    }

    public void ReturnGameObject()
    {
        note.SetActive(true);
        note.transform.SetParent(null);
        note.transform.position = Vector3.zero;
        note.SetActive(false);

        if (notes.Peek() == note)
        {
            notes.Dequeue();
        }
        else
        {
            Debug.LogError(this + "音符消除顺序出错");
        }

        GameObjectPool.instance.ReturnNotes(note, noteType);
    }
}
