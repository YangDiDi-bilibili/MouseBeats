using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NotesInfo;

public class NotesGenerate : MonoBehaviour
{
    public NoteType noteType;
    public int layer;

    public SpriteRenderer sprite;
    public BoxCollider2D boxCollider;

    public bool doEnabled = true;

    public NotesInfo spritesLeft;
    public NotesInfo spritesRight;

    private void OnEnable()
    {
        List<Sprite> sprites = new List<Sprite>();
        for (int i = 0; i < 8; i++)
        {
            if (i % 2 == 0)
            {
                sprites.Add(spritesLeft.sprites[i / 2]);
            }
            else
            {
                sprites.Add(spritesRight.sprites[i / 2]);
            }
        }

        sprite.sprite = sprites[(int)noteType];
    }

    /// <summary>
    /// 0为perfect，1为good，以此类推
    /// </summary>
    /// <param name="clearDetermined"></param>
    public void ClearGameObject(int clearDetermined)
    {
        if (GameManager.instance.setting.doDetermined)
        {
            if (GameManager.instance.setting.doDebugClear)
            {
                Debug.Log(gameObject.transform.parent.gameObject + "被消除");
            }

            doEnabled = false;
            sprite.enabled = false;
            boxCollider.enabled = false;

            if (clearDetermined == 0 || clearDetermined == 1)
            {
                switch (GetNoteType(gameObject))
                {
                    case 0:
                        AudioManager.instance.PlaySound("Tap");
                        break;
                    case 1:
                        AudioManager.instance.PlaySound("Drag");
                        break;
                    case 2:
                        AudioManager.instance.PlaySound("Flick");
                        break;
                    case 3:
                        //nothing to do...
                        break;
                    default:
                        break;
                }
            }
            else if (clearDetermined == 2 || clearDetermined == 3)
            {

            }
            else
            {
                Debug.LogError("无法处理的数字");
            }
        }
    }
}
