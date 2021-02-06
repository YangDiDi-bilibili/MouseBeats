using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NotesInfo;

public class NotesGenerate : MonoBehaviour
{
    private GameObject note;

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
