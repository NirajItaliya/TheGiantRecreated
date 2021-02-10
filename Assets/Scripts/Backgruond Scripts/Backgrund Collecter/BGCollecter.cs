using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollecter : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Backgruond")
		{
			target.gameObject.SetActive(false);
		}
	}
}
