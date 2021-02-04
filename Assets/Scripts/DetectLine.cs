﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLine : MonoBehaviour
{
	public static bool doLeftDown;
	public static bool doRightDown;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			doLeftDown = true;
		}

		if (Input.GetMouseButtonDown(1))
		{
			doRightDown = true;
		}
	}

    private void FixedUpdate()
    {
        if (doLeftDown)
        {
            Debug.Log("Left Button Down");
            if (BadDetect.badNotesLeft.Count != 0)
            {
                if (GoodDetect.goodNotesLeft.Count != 0)
                {
                    if (PerfectDetect.perfectNotesLeft.Count != 0)
                    {

                    }
                }
                else
                {
                    ReturnNote(BadDetect.badNotesLeft.Peek());
                    ScoreManager.Bad();
                    Debug.Log("Bad!");
                }
            }
        }

        doLeftDown = false;
		doRightDown = false;
    }

	private NotesGenerate.NoteType GetNoteType(GameObject gObj)
    {
		var tmp = gObj.GetComponentInParent<NotesGenerate>().noteType;
		return tmp;
    }

    private void ReturnNote(GameObject gObj)
    {
        gObj.GetComponentInParent<NotesGenerate>().ReturnGameObject();
    }

    public static bool GetNoteDirection(GameObject gObj)
    {
        var tmp = gObj.GetComponentInParent<NotesGenerate>().noteType;

        bool a;
        switch (tmp)
        {
            case NotesGenerate.NoteType.leftTap:
                a = true;
                break;
            case NotesGenerate.NoteType.rightTap:
                a = false;
                break;
            case NotesGenerate.NoteType.leftHold:
                a = true;
                break;
            case NotesGenerate.NoteType.rightHold:
                a = false;
                break;
            case NotesGenerate.NoteType.leftFlick:
                a = true;
                break;
            case NotesGenerate.NoteType.rightFlick:
                a = false;
                break;
            case NotesGenerate.NoteType.leftDrag:
                a = true;
                break;
            case NotesGenerate.NoteType.rightDrag:
                a = false;
                break;
            default:
                a = true;
                break;
        }
        return a;
    }
}
