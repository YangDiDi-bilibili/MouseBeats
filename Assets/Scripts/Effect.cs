using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public bool doActive = true;

    private void Update()
    {
        if (!doActive)
        {
            Destroy(gameObject);
        }
    }
}
