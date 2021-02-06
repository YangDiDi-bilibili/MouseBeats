using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VoidEventListener : MonoBehaviour
{
    public VoidGameEvents events;
    public UnityEvent action;

    private void OnEnable()
    {
        events.AddListener(this);
    }

    private void OnDisable()
    {
        events.RemoveListener(this);
    }

    public void OnEventRaised()
    {
        action.Invoke();
    }
}
