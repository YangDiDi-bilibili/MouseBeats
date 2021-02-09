using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesInfo : MonoBehaviour
{
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

    public static bool GetNoteDirection(GameObject gObj)
    {
        var tmp = gObj.GetComponent<NotesGenerate>().noteType;

        bool a;
        switch (tmp)
        {
            case NoteType.leftTap:
                a = true;
                break;
            case NoteType.rightTap:
                a = false;
                break;
            case NoteType.leftHold:
                a = true;
                break;
            case NoteType.rightHold:
                a = false;
                break;
            case NoteType.leftFlick:
                a = true;
                break;
            case NoteType.rightFlick:
                a = false;
                break;
            case NoteType.leftDrag:
                a = true;
                break;
            case NoteType.rightDrag:
                a = false;
                break;
            default:
                a = true;
                break;
        }
        return a;
    }

    public static int GetNoteType(GameObject gObj)
    {
        var tmp = gObj.GetComponent<NotesGenerate>().noteType;
        int a = (int)tmp / 2;
        return a;
    }
}
