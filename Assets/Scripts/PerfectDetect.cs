using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectDetect : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            collision.GetComponent<Note>().Dead();
            Debug.Log("Perfect");
        }
    }
}
