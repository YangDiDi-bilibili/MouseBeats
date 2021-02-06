using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NotesInfo;
public class DetectLine : MonoBehaviour
{
    public static bool doLeft;
    public static bool doRight;

	public static bool doLeftDown;
	public static bool doRightDown;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			doLeftDown = true;
            doLeft = true;
		}

		if (Input.GetMouseButtonDown(1))
		{
			doRightDown = true;
            doRight = true;
		}

        if (Input.GetMouseButtonUp(0))
        {
            doLeft = false;
        }

        if (Input.GetMouseButtonUp(1))
        {
            doRight = false;
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
                    if (GoodDetect.goodNotesLeft.Peek() == BadDetect.badNotesLeft.Peek())
                    {
                        if (PerfectDetect.perfectNotesLeft.Count != 0)
                        {
                            if (PerfectDetect.perfectNotesLeft.Peek() == BadDetect.badNotesLeft.Peek())
                            {ScoreManager.Perfect(BadDetect.badNotesLeft.Peek().transform.position);
                                ReturnNote(BadDetect.badNotesLeft.Peek());
                            }
                            else
                            {ScoreManager.Good();
                                ReturnNote(BadDetect.badNotesLeft.Peek());
                            }
                        }
                        else
                        {ScoreManager.Good();
                            ReturnNote(BadDetect.badNotesLeft.Peek());
                        }
                    }
                    else
                    {ScoreManager.Bad();
                        ReturnNote(BadDetect.badNotesLeft.Peek());
                    }
                }
                else
                {ScoreManager.Bad();
                    ReturnNote(BadDetect.badNotesLeft.Peek());
                }
            }
        }

        if (doRightDown)
        {
            Debug.Log("Right Button Down");
            if (BadDetect.badNotesRight.Count != 0)
            {
                if (GoodDetect.goodNotesRight.Count != 0)
                {
                    if (GoodDetect.goodNotesRight.Peek() == BadDetect.badNotesRight.Peek())
                    {
                        if (PerfectDetect.perfectNotesRight.Count != 0)
                        {
                            if (PerfectDetect.perfectNotesRight.Peek() == BadDetect.badNotesRight.Peek())
                            {ScoreManager.Perfect(BadDetect.badNotesRight.Peek().transform.position);
                                ReturnNote(BadDetect.badNotesRight.Peek());
                            }
                            else
                            {ScoreManager.Good();
                                ReturnNote(BadDetect.badNotesRight.Peek());
                            }
                        }
                        else
                        {ScoreManager.Good();
                            ReturnNote(BadDetect.badNotesRight.Peek());
                        }
                    }
                    else
                    {ScoreManager.Bad();
                        ReturnNote(BadDetect.badNotesRight.Peek());
                    }
                }
                else
                {
                    ScoreManager.Bad();
                    ReturnNote(BadDetect.badNotesRight.Peek());
                }
            }
        }

        if (doLeft)
        {
            if (PerfectDetect.perfectNotesLeft.Count != 0)
            {
                if(GetNoteType(PerfectDetect.perfectNotesLeft.Peek()) == 3)
                {
                    ScoreManager.Perfect(PerfectDetect.perfectNotesLeft.Peek().transform.position);
                    ReturnNote(PerfectDetect.perfectNotesLeft.Peek());
                }
            }
        }

        if (doRight)
        {
            if (PerfectDetect.perfectNotesRight.Count != 0)
            {
                if (GetNoteType(PerfectDetect.perfectNotesRight.Peek()) == 3)
                {
                    ScoreManager.Perfect(PerfectDetect.perfectNotesRight.Peek().transform.position);
                    ReturnNote(PerfectDetect.perfectNotesRight.Peek());
                }
            }
        }

        doLeftDown = false;
		doRightDown = false;
    }

    private void ReturnNote(GameObject gObj)
    {
        gObj.GetComponentInParent<NotesGenerate>().ReturnGameObject();
    }
}
