using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static NotesInfo;

public class DetectLine : MonoBehaviour
{
    public int layer = 0;

    public bool doLeft;
    public bool doRight;

	public bool doLeftDown;
	public bool doRightDown;

	private void Update()
	{
        if (GameManager.instance.setting.doDetermined)
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
    }

    private void FixedUpdate()
    {
        if (doLeftDown)
        {
            DebugMessage("Left Button Down");
            if (BadDetect.badNotesLeft.Count != 0)
            {
                if (GetNoteType(BadDetect.badNotesLeft.Peek()) == 0)
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
                                    ReturnNote(BadDetect.badNotesLeft.Peek(), 0);
                                }
                                else
                                {
                                    ScoreManager.Good();
                                    ReturnNote(BadDetect.badNotesLeft.Peek(), 1);
                                }
                            }
                            else
                            {
                                ScoreManager.Good();
                                ReturnNote(BadDetect.badNotesLeft.Peek(), 1);
                            }
                        }
                        else
                        {
                            ScoreManager.Bad();
                            ReturnNote(BadDetect.badNotesLeft.Peek(), 2);
                        }
                    }
                    else
                    {
                        ScoreManager.Bad();
                        ReturnNote(BadDetect.badNotesLeft.Peek(), 2);
                    }
                }
            }
            doLeftDown = false;
        }

        if (doRightDown)
        {
            DebugMessage("Right Button Down");
            if (BadDetect.badNotesRight.Count != 0)
            {
                if (GetNoteType(BadDetect.badNotesRight.Peek()) == 0)
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
                                    ReturnNote(BadDetect.badNotesRight.Peek(), 0);
                                }
                                else
                                {
                                    ScoreManager.Good();
                                    ReturnNote(BadDetect.badNotesRight.Peek(), 1);
                                }
                            }
                            else
                            {
                                ScoreManager.Good();
                                ReturnNote(BadDetect.badNotesRight.Peek(), 1);
                            }
                        }
                        else
                        {
                            ScoreManager.Bad();
                            ReturnNote(BadDetect.badNotesRight.Peek(), 2);
                        }
                    }
                    else
                    {
                        ScoreManager.Bad();
                        ReturnNote(BadDetect.badNotesRight.Peek(), 2);
                    }
                }
            }
            doRightDown = false;
        }

        if (doLeft)
        {
            if (PerfectDetect.perfectNotesLeft.Count != 0)
            {
                if(GetNoteType(PerfectDetect.perfectNotesLeft.Peek()) == 1)
                {
                    ScoreManager.Perfect();
                    ReturnNote(PerfectDetect.perfectNotesLeft.Peek(), 0);
                }
                else if (GetNoteType(PerfectDetect.perfectNotesLeft.Peek()) == 2)
                {
                    var v2 = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                    if (Vector2.Distance(v2, Vector2.zero) > 0.1)
                    {
                        ScoreManager.Perfect();
                        ReturnNote(PerfectDetect.perfectNotesLeft.Peek(), 0);
                    }
                }
            }
        }

        if (doRight)
        {
            if (PerfectDetect.perfectNotesRight.Count != 0)
            {
                if (GetNoteType(PerfectDetect.perfectNotesRight.Peek()) == 1)
                {
                    ScoreManager.Perfect();
                    ReturnNote(PerfectDetect.perfectNotesRight.Peek(), 0);
                }
                else if (GetNoteType(PerfectDetect.perfectNotesRight.Peek()) == 2)
                {
                    var v2 = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                    if (Vector2.Distance(v2, Vector2.zero) > 0.1)
                    {
                        ScoreManager.Perfect();
                        ReturnNote(PerfectDetect.perfectNotesRight.Peek(), 0);
                    }
                }
            }
        }
    }

    public void DebugMessage(string message)
    {
        if (GameManager.instance.setting.doDebugMouse)
        {
            Debug.Log(message);
        }
    }

    private void ReturnNote(GameObject gObj,int determined)
    {
        gObj.GetComponent<NotesGenerate>().ClearGameObject(determined);
    }
}
