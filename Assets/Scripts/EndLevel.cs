using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EndLevel : MonoBehaviour
{
    public VoidGameEvents onGameStopped;

    public void OnGameStopped()
    {
        onGameStopped.Raise();
    }
}
