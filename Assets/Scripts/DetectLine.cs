using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DetectLine : MonoBehaviour
{
	public bool doLeft;
	public bool doRight;

	public bool doLeftDown;
	public bool doRightDown;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			doLeft = true;
			doLeftDown = true;
		}

		if(Input.GetMouseButtonUp(0))
		{
			doLeft = false;
		}

		if (Input.GetMouseButtonDown(1))
		{
			doRight = true;
			doRightDown = true;
		}
		if(Input.GetMouseButtonUp(1))
		{
			doRight = false;
		}
	}
}
