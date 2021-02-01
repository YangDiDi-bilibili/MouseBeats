using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLine : MonoBehaviour
{
	public bool left;
	public bool right;

	private bool doLeftDown;
	private bool doRightDown;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			left = true;
			doLeftDown = true;
		}

		if(Input.GetMouseButtonUp(0))
		{
			left = false;
		}

		if (Input.GetMouseButtonDown(1))
		{
			right = true;
			doRightDown = true;
		}
		if(Input.GetMouseButtonUp(1))
		{
			right = false;
		}
	}

	private void FixedUpdate()
	{
		if (doLeftDown)
		{


			doLeftDown = false;
		}

		if (doRightDown)
		{


			doRightDown = false;
		}
	}


}
