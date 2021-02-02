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
        switch (noteType)
        {
            case NoteType.leftTap:
                note = GameObjectPool.instance.GetLeftTap();
                note.transform.position = gameObject.transform.position;
                note.transform.parent = gameObject.transform;
                break;
            case NoteType.rightTap:
                break;
            case NoteType.leftHold:
                break;
            case NoteType.rightHold:
                break;
            case NoteType.leftFlick:
                break;
            case NoteType.rightFlick:
                break;
            case NoteType.leftDrag:
                break;
            case NoteType.rightDrag:
                break;
            default:
                break;
        }
    }

    public void ReturnGameObject()
    {
        switch (noteType)
        {
            case NoteType.leftTap:
                GameObjectPool.instance.ReturnLeftTap(note);
                break;
            case NoteType.rightTap:
                break;
            case NoteType.leftHold:
                break;
            case NoteType.rightHold:
                break;
            case NoteType.leftFlick:
                break;
            case NoteType.rightFlick:
                break;
            case NoteType.leftDrag:
                break;
            case NoteType.rightDrag:
                break;
            default:
                break;
        }
    }
}
