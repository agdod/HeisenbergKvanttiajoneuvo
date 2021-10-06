using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerStand : MonoBehaviour
{
	[SerializeField] private float delay;
	private void Awake()
	{
		EventHandler.onStartTurn += FadeFlowerStand;
	}

	private void OnDisable()
	{
		EventHandler.onStartTurn -= FadeFlowerStand;
	}

	private void FadeFlowerStand()
	{
		StartCoroutine(DisableFlowerStand());
	}

	IEnumerator DisableFlowerStand()
	{
		yield return new WaitForSeconds(delay);
		gameObject.SetActive(false);
	}
}
