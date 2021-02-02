using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesGenerate : MonoBehaviour
{
    private GameObject note;

    private void OnEnable()
    {
        note = GameObjectPool.instance.GetLeftTap();
        note.transform.position = gameObject.transform.position;
        note.transform.parent = gameObject.transform;
    }
}
