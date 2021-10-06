using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
	[SerializeField] private Vector3Variable destination;

	void Update()
	{
		if (destination != null)
		{
			transform.LookAt(destination.value);
		}
	}
}
