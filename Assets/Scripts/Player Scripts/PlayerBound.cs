using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBound : MonoBehaviour
{
	private float minX, maxX;

	// Use this for initialization
	void Start()
	{
		SetMinAndMaxX();
	}

	void Update()
	{
		if (transform.position.x < minX)
		{
			Vector3 temp = transform.position;
			temp.x = minX;
			transform.position = temp;
		}

		if (transform.position.x > maxX)
		{
			Vector3 temp = transform.position;
			temp.x = maxX;
			transform.position = temp;
		}

	}

	void SetMinAndMaxX()
	{
		Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

		minX = -bounds.x;
		maxX = bounds.x;
	}
}
