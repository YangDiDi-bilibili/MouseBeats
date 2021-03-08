using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDelay : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            GameManager.instance.StartGame();
            Destroy(gameObject);
        }
    }
}
