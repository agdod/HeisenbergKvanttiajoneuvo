using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private GameObject player;

	// Camera offset
	[SerializeField][Tooltip("Camera offset from player")] private Vector3 cameraOffset;

	private void Update()
	{
		this.transform.position = player.transform.position + cameraOffset;
	}
}
