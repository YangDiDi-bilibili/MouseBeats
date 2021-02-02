using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [Header("音符")]
    private Queue<GameObject> tapLeftPool = new Queue<GameObject>();
    private Queue<GameObject> tapRightPool = new Queue<GameObject>();
    public GameObject tapLeft;
    public GameObject tapRight;
    public int notesInstanceCount;

    [Header("特效")]
    private Queue<GameObject> perfectPool = new Queue<GameObject>();
    private Queue<GameObject> goodPool = new Queue<GameObject>();
    public GameObject perfect;
    public GameObject good;
    public int effectsInstanceCount;

    public static GameObjectPool instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < notesInstanceCount; i++)
        {
            tapLeftPool.Enqueue(GameObject.Instantiate(tapLeft, Vector3.zero, Quaternion.identity));
            tapRightPool.Enqueue(GameObject.Instantiate(tapRight, Vector3.zero, Quaternion.identity));
        }

        for (int i = 0; i < effectsInstanceCount; i++)
        {
            perfectPool.Enqueue(GameObject.Instantiate(perfect, Vector3.zero, Quaternion.identity));
            goodPool.Enqueue(GameObject.Instantiate(good, Vector3.zero, Quaternion.identity));
        }
    }

    public GameObject GetLeftTap()
    {
        return tapLeftPool.Dequeue();
    }
}
