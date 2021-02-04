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

    private void OnEnable()
    {
        note = GameObjectPool.instance.GetNote(noteType);
        note.transform.position = gameObject.transform.position;
        note.transform.parent = gameObject.transform;
    }

    public void ReturnGameObject()
    {
        note.SetActive(true);
        note.transform.SetParent(null);
        note.transform.position = Vector3.zero;
        note.SetActive(false);

        GameObjectPool.instance.ReturnNotes(note, noteType);
    }
}
