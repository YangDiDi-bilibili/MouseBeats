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

    public void ClearGameObject()
    {
        doEnabled = false;
        sprite.enabled = false;
        boxCollider.enabled = false;
    }
}
