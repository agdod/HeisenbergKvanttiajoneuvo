using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{	
	[SerializeField] private Vector3 playerStartPosition;
	[SerializeField] private GameController gameController;
	[SerializeField] float transition;
	[SerializeField] private float rotationDuration = 0.5f;

	private void Start()
	{
		transform.position = playerStartPosition;
	}

	private bool OutOfBounds()
	{
		if (transform.position.x > -2405 && transform.position.x < 240 && transform.position.z > -240 && transform.position.z < 240)
		{
			return false;
		}
		else
		{
			Debug.Log("out of bounds");
			return true;
		}
	}

	private void ResetPosition()
	{
		StopAllCoroutines();
		transform.position = playerStartPosition;
		PlayerEndTurn();
	}

	// Rotate the player THEN
	// Move the player.
	public void RoateAndMovePlayer(float pVelocity, float pDirection)
	{
		gameController.StartTurn();
		Quaternion targetRoatation = Quaternion.Euler(new Vector3(0, pDirection, 0));
		StartCoroutine(RotatePlayer(targetRoatation, rotationDuration, pVelocity));
	}

	// Pass in the toRoation as user-friendly Euler Angle.
	private IEnumerator RotatePlayer(Quaternion toRotation, float duration, float pVelocity)
	{
		float time = 0;
		Quaternion fromRotation = transform.rotation;
		while (time < duration)
		{
			transform.rotation = Quaternion.Lerp(fromRotation, toRotation, time / duration);
			time += Time.deltaTime;
			yield return null;
		}
		transform.rotation = toRotation;
		// Once Coroutine for player rotation has finished move the player.
		StartCoroutine(MovePlayer(pVelocity));
	}

	private IEnumerator MovePlayer(float pVelocity)
	{
		transition = 0f;
		// move the player 
		while (transition < 1.0f)
		{
			if (!OutOfBounds())
			{
				transform.Translate(Vector3.forward * pVelocity * Time.deltaTime);
				transition += Time.deltaTime * 1 / gameController.TimeFrame;
			}
			else
			{
				transition = 1.0f;
				transform.Translate(0, 0, 0);
				ResetPosition();
			}

			yield return new WaitForEndOfFrame();
		}
		PlayerEndTurn();
		Debug.Log("TurnOver");
	}

	public void PlayerEndTurn()
	{
		transition = 1.0f;
		gameController.EndTurn();

	}
}
