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
        GameObject tmp;
        for (int i = 0; i < notesInstanceCount; i++)
        {
            tmp = GameObject.Instantiate(tapLeft, Vector3.zero, Quaternion.identity);
            tmp.SetActive(false);
            tapLeftPool.Enqueue(tmp);

            tmp = GameObject.Instantiate(tapRight, Vector3.zero, Quaternion.identity);
            tmp.SetActive(false);
            tapRightPool.Enqueue(tmp);
        }

        for (int i = 0; i < effectsInstanceCount; i++)
        {
            tmp = GameObject.Instantiate(perfect, Vector3.zero, Quaternion.identity);
            tmp.SetActive(false);
            perfectPool.Enqueue(tmp);

            tmp = GameObject.Instantiate(good, Vector3.zero, Quaternion.identity);
            tmp.SetActive(false);
            goodPool.Enqueue(tmp);
        }
    }

    public GameObject GetLeftTap()
    {
        GameObject tmp = tapLeftPool.Dequeue();
        tmp.SetActive(true);
        return tmp;
    }


}
