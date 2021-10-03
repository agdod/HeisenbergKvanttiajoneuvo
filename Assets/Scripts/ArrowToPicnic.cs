using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowToPicnic : MonoBehaviour
{
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject arrowVics;
	[SerializeField] private GameController gameController;
	[SerializeField] private Vector3 Vdestination;
	[SerializeField] private Vector3 VPlayerPos;
	[SerializeField] private Vector3 vecPlayerDestin;
	[SerializeField] private float angleDest;

	private void Start()
	{
		UpdateArrow();
		Vdestination = gameController.Destination; // vector of the destination
	}

	private void Update()
	{
		transform.LookAt(Vdestination);
	}

	public void UpdateArrow()
	{
		VPlayerPos = player.transform.position;   // vector of the player's position


		vecPlayerDestin = Vdestination - VPlayerPos; // vector connecting the player's and the destination positions

		angleDest = Vector3.Angle(vecPlayerDestin, transform.forward); // get the angle of that vector

		// rotate the arrow 
		transform.RotateAround(arrowVics.transform.position, Vector3.up, angleDest);
	}
}
