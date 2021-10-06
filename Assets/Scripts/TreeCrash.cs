using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCrash : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			// Raise a crash event and play crash animation -- TODO
			PlayerMovement player = other.GetComponent<PlayerMovement>();
			Debug.Log("Crashed wiht a tree!");
			player.EventHandler.OnEndTurn();
		}
	}
}
