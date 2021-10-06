using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
	[SerializeField] private Vector3Variable destination;

	private void Awake()
	{
		EventHandler.onGameOver += HideArrow;
		this.gameObject.SetActive(true);
	}

	private void OnDisable()
	{
		EventHandler.onGameOver -= HideArrow;
	}

	void Update()
	{
		if (destination != null)
		{
			transform.LookAt(destination.value);
		}
	}

	private void HideArrow()
	{
		this.gameObject.SetActive(false);
	}

}
