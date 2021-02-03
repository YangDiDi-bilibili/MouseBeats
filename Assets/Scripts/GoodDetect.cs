using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodDetect : DetectLine
{
    public Queue<GameObject> goodNotes = new Queue<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            goodNotes.Enqueue(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //note离开good collider，实现miss
        if (collision.CompareTag("Note"))
        {
            if (goodNotes.Peek() == collision.gameObject)
            {
                goodNotes.Dequeue();
            }
            else
            {
                Debug.LogError(collision.gameObject + "不是good队列的首位");
            }
            collision.GetComponentInParent<NotesGenerate>().ReturnGameObject();
        }
    }

    private void FixedUpdate()
    {
        if (base.doLeftDown)
        {
            if (GameObjectPool.leftTapCount != 0)
            {
                if (goodNotes.Count == 0)
                {
                    NotesGenerate.notes.Peek().GetComponentInParent<NotesGenerate>().ReturnGameObject();
                    ScoreManager.Miss();
                }
                else
                {
                    //perfect?
                    var perfect = PerfectDetect.GetPerfectPeek();
                    if (perfect == goodNotes.Peek())
                    {
                        if (perfect.GetComponentInParent<NotesGenerate>().noteType == NotesGenerate.NoteType.leftTap)
                        {
                            ScoreManager.Perfect();

                        }
                        else
                        {

                        }
                    }
                }
            }
            doLeftDown = false;
        }

        if (base.doRightDown)
        {

            doRightDown = false;
        }
    }
}
