using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="EventObjects/Void")]
public class VoidGameEvents : ScriptableObject
{
    private List<VoidEventListener> listeners = new List<VoidEventListener>();

    public void AddListener(VoidEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
        else
        {
            Debug.LogError(listener + "已存在于listener list中");
        }
    }

    public void RemoveListener(VoidEventListener listener)
    {
        listeners.Remove(listener);
    }

    public void Raise()
    {
        foreach (var item in listeners)
        {
            item.OnEventRaised();
        }
    }
}
