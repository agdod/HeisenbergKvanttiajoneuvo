using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
	[SerializeField] private EventHandler eventHandler;

	// Static so all OutOfBounds can access same varible, can only be triggered once
	// if player goes off in a corner hitting two walls.
	[SerializeField] private static bool hasTriggered;

	private static void Awake()
	{
		EventHandler.onStartTurn += TriggerReset;
	}

	private static void OnDisable()
	{
		EventHandler.onStartTurn -= TriggerReset;
	}

	private static void TriggerReset()
	{
		hasTriggered = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && !hasTriggered)
		{
			hasTriggered = true;
			eventHandler.OnOutOfBounds();
		}
	}



}
