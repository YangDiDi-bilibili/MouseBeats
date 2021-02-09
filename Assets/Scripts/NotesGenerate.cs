using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NotesInfo;

public class NotesGenerate : MonoBehaviour
{
    public NoteType noteType;

    public SpriteRenderer sprite;
    public BoxCollider2D boxCollider;

    public bool doEnabled = true;

    public List<Sprite> sprites = new List<Sprite>();

    private void OnEnable()
    {
        sprite.sprite = sprites[(int)noteType];
    }

    public void ClearGameObject()
    {
        doEnabled = false;
        sprite.enabled = false;
        boxCollider.enabled = false;
    }
}
