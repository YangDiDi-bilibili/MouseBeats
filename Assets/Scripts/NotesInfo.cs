using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NoteInfo")]
public class NotesInfo : ScriptableObject
{
    public string notesName;
    public Sprite[] sprites = new Sprite[4];

    public enum NoteType
    {
        leftTap,
        rightTap,
        leftDrag,
        rightDrag,
        leftFlick,
        rightFlick,
        leftHold,
        rightHold
    }

    public static bool GetNoteDirection(GameObject gObj)
    {
        var tmp = gObj.GetComponent<NotesGenerate>().noteType;
        bool a;
        a = (bool)((int)tmp % 2 == 0);
        return a;
    }

    public static int GetNoteType(GameObject gObj)
    {
        var tmp = gObj.GetComponent<NotesGenerate>().noteType;
        int a = (int)tmp / 2;
        return a;
    }
}
