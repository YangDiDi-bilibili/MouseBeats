using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static NotesInfo;
public class DetectLine : MonoBehaviour
{
    public bool doLeft;
    public bool doRight;

	public bool doLeftDown;
	public bool doRightDown;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
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
                            {
                                ScoreManager.Perfect();
                                ReturnNote(BadDetect.badNotesLeft.Peek());
                            }
                            else
                            {
                                ScoreManager.Good();
                                ReturnNote(BadDetect.badNotesLeft.Peek());
                            }
                        }
                        else
                        {
                            ScoreManager.Good();
                            ReturnNote(BadDetect.badNotesLeft.Peek());
                        }
                    }
                    else
                    {
                        ScoreManager.Bad();
                        ReturnNote(BadDetect.badNotesLeft.Peek());
                    }
                }
                else
                {
                    ScoreManager.Bad();
                    ReturnNote(BadDetect.badNotesLeft.Peek());
                }
            }
            doLeftDown = false;
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
                            {
                                ScoreManager.Perfect();
                                ReturnNote(BadDetect.badNotesRight.Peek());
                            }
                            else
                            {
                                ScoreManager.Good();
                                ReturnNote(BadDetect.badNotesRight.Peek());
                            }
                        }
                        else
                        {
                            ScoreManager.Good();
                            ReturnNote(BadDetect.badNotesRight.Peek());
                        }
                    }
                    else
                    {
                        ScoreManager.Bad();
                        ReturnNote(BadDetect.badNotesRight.Peek());
                    }
                }
                else
                {
                    ScoreManager.Bad();
                    ReturnNote(BadDetect.badNotesRight.Peek());
                }
            }
            doRightDown = false;
        }

        if (doLeft)
        {
            if (PerfectDetect.perfectNotesLeft.Count != 0)
            {
                if(GetNoteType(PerfectDetect.perfectNotesLeft.Peek()) == 3)
                {
                    ScoreManager.Perfect();
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
                    ScoreManager.Perfect();
                    ReturnNote(PerfectDetect.perfectNotesRight.Peek());
                }
            }
        }
    }

    private void ReturnNote(GameObject gObj)
    {
        gObj.GetComponent<NotesGenerate>().ClearGameObject();
    }
}
