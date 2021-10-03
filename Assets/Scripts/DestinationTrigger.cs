using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("yaay arrived at pinic spread.");
			PlayerMovement player = other.GetComponent<PlayerMovement>();
			player.PlayerArrived();
			// Stop player movement.
			// Register Game Over
			// Registerr game won.
		}
	}
}
