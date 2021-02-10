using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
	// Start is called before the first frame update
	void OnEnable()
	{
		Invoke("DestroyCollectable", 6.0f);
	}

	void DestroyCollectable()
	{
		gameObject.SetActive(false);
	}
}
