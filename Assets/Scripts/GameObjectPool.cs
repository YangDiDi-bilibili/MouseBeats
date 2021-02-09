using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NotesInfo;

public class GameObjectPool : MonoBehaviour
{
    [Header("音符")]
    private Queue<GameObject> leftTapPool = new Queue<GameObject>();
    private Queue<GameObject> rightTapPool = new Queue<GameObject>();
    public GameObject leftTap;
    public GameObject rightTap;
    public int tapInstanceCount;
    public static int leftTapCount = 0;
    public static int rightTapCount = 0;

    private Queue<GameObject> leftHoldPool = new Queue<GameObject>();
    private Queue<GameObject> rightHoldPool = new Queue<GameObject>();
    public GameObject leftHold;
    public GameObject rightHold;
    public int holdInstanceCount;
    public static int leftHoldCount = 0;
    public static int rightHoldCount = 0;

    private Queue<GameObject> leftFlickPool = new Queue<GameObject>();
    private Queue<GameObject> rightFlickPool = new Queue<GameObject>();
    public GameObject leftFlick;
    public GameObject rightFlick;
    public int flickInstanceCount;
    public static int leftFlickCount = 0;
    public static int rightFlickCount = 0;

    private Queue<GameObject> leftDragPool = new Queue<GameObject>();
    private Queue<GameObject> rightDragPool = new Queue<GameObject>();
    public GameObject leftDrag;
    public GameObject rightDrag;
    public int dragInstanceCount;
    public static int leftDragCount = 0;
    public static int rightDragCount = 0;

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

        leftTapCount = 0;
        rightTapCount = 0;
        leftHoldCount = 0;
        rightHoldCount = 0;
        leftFlickCount = 0;
        rightFlickCount = 0;
        leftDragCount = 0;
        rightDragCount = 0;

        for (int i = 0; i < tapInstanceCount; i++)
        {
            tmp = GameObject.Instantiate(leftTap, Vector3.zero, Quaternion.identity);
            tmp.SetActive(false);
            leftTapPool.Enqueue(tmp);

            tmp = GameObject.Instantiate(rightTap, Vector3.zero, Quaternion.identity);
            tmp.SetActive(false);
            rightTapPool.Enqueue(tmp);
        }

        for (int i = 0; i < holdInstanceCount; i++)
        {
            tmp = GameObject.Instantiate(leftHold, Vector3.zero, Quaternion.identity);
            tmp.SetActive(false);
            leftHoldPool.Enqueue(tmp);

            tmp = GameObject.Instantiate(rightHold, Vector3.zero, Quaternion.identity);
            tmp.SetActive(false);
            rightHoldPool.Enqueue(tmp);
        }

        for (int i = 0; i < flickInstanceCount; i++)
        {
            tmp = GameObject.Instantiate(leftFlick, Vector3.zero, Quaternion.identity);
            tmp.SetActive(false);
            leftFlickPool.Enqueue(tmp);

            tmp = GameObject.Instantiate(rightFlick, Vector3.zero, Quaternion.identity);
            tmp.SetActive(false);
            rightFlickPool.Enqueue(tmp);
        }

        for (int i = 0; i < dragInstanceCount; i++)
        {
            tmp = GameObject.Instantiate(leftDrag, Vector3.zero, Quaternion.identity);
            tmp.SetActive(false);
            leftDragPool.Enqueue(tmp);

            tmp = GameObject.Instantiate(rightDrag, Vector3.zero, Quaternion.identity);
            tmp.SetActive(false);
            rightDragPool.Enqueue(tmp);
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

    public GameObject GetNote(NoteType note)
    {
        GameObject tmp;

        switch (note)
        {
            case NoteType.leftTap:
                leftTapCount++;
                tmp = leftTapPool.Dequeue();
                break;
            case NoteType.rightTap:
                rightTapCount++;
                tmp = rightTapPool.Dequeue();
                break;
            case NoteType.leftHold:
                leftHoldCount++;
                tmp = leftHoldPool.Dequeue();
                break;
            case NoteType.rightHold:
                rightHoldCount++;
                tmp = rightHoldPool.Dequeue();
                break;
            case NoteType.leftFlick:
                leftFlickCount++;
                tmp = leftFlickPool.Dequeue();
                break;
            case NoteType.rightFlick:
                rightFlickCount++;
                tmp = rightFlickPool.Dequeue();
                break;
            case NoteType.leftDrag:
                leftDragCount++;
                tmp = leftDragPool.Dequeue();
                break;
            case NoteType.rightDrag:
                rightDragCount++;
                tmp = rightDragPool.Dequeue();
                break;
            default:
                leftTapCount++;
                tmp = leftTapPool.Dequeue();
                Debug.LogError(this + "输入有误");
                break;
        }

        tmp.SetActive(true);
        return tmp;
    }

    public void ReturnNotes(GameObject tmp,NoteType type)
    {
        switch (type)
        {
            case NoteType.leftTap:
                leftTapCount--;
                leftTapPool.Enqueue(tmp);
                break;
            case NoteType.rightTap:
                rightTapCount--;
                rightTapPool.Enqueue(tmp);
                break;
            case NoteType.leftHold:
                leftHoldCount--;
                leftHoldPool.Enqueue(tmp);
                break;
            case NoteType.rightHold:
                rightHoldCount--;
                rightHoldPool.Enqueue(tmp);
                break;
            case NoteType.leftFlick:
                leftFlickCount--;
                leftFlickPool.Enqueue(tmp);
                break;
            case NoteType.rightFlick:
                rightFlickCount--;
                rightFlickPool.Enqueue(tmp);
                break;
            case NoteType.leftDrag:
                leftDragCount--;
                leftDragPool.Enqueue(tmp);
                break;
            case NoteType.rightDrag:
                rightDragCount--;
                rightDragPool.Enqueue(tmp);
                break;
            default:
                leftTapCount--;
                leftTapPool.Enqueue(tmp);
                Debug.LogError(this + "输入有误");
                break;
        }
    }

    public GameObject GetPerfectEffect(Vector3 trans)
    {
        var tmp = perfectPool.Dequeue();
        tmp.SetActive(true);
        tmp.transform.position = trans;
        perfectPool.Enqueue(tmp);
        return tmp;
    }

    public void ReturnPerfectEffect(GameObject gObj)
    {
        perfectPool.Enqueue(gObj);
        gObj.SetActive(false);
    }
}
