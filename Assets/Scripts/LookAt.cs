using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
	[SerializeField] private Transform destination;

	IEnumerator Start()
	{
		yield return new WaitForSeconds(0.1f);
		destination = GameObject.FindGameObjectWithTag("Finish").transform;
	}

	void Update()
	{
		if (destination != null)
		{
			transform.LookAt(destination);
		}
	}
}
