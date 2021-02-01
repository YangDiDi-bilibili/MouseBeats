using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
	Animator ani;

    public void Dead()
    {
		ani.SetBool("Dead", true);
    }

    public void Pressed()
    {
        ani.SetBool("Pressed", true);
    }

    private void OnEnable()
	{
        ani = GetComponent<Animator>();
        ani.SetBool("Dead", false);
        ani.SetBool("Pressed", false);
    }
}
