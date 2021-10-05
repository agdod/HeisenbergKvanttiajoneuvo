using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private EventHandler eventHandler;

	[SerializeField] private Vector3 playerStartPosition;
	[SerializeField] private GameController gameController;
	[SerializeField] float transition;
	[SerializeField] private float rotationDuration = 0.5f;
	[Space]
	[Header("Uncertainity Values")]
	[SerializeField] private floatVarible velocity;
	[SerializeField] private floatVarible direction;

	private void Awake()
	{
		EventHandler.onStartTurn += RoateAndMovePlayer;

	}

	private void OnDisable()
	{
		// unreigster from events
		EventHandler.onStartTurn -= RoateAndMovePlayer;

	}

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
		eventHandler.OnEndTurn();
	}

	// Rotate the player THEN
	// Move the player.
	public void RoateAndMovePlayer()
	{
		Quaternion targetRoatation = Quaternion.Euler(new Vector3(0, direction.value, 0));
		StartCoroutine(RotatePlayer(targetRoatation, rotationDuration));
	}

	// Pass in the toRoation as user-friendly Euler Angle.
	private IEnumerator RotatePlayer(Quaternion toRotation, float duration)
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
		StartCoroutine(MovePlayer());
	}

	private IEnumerator MovePlayer()
	{
		transition = 0f;
		// move the player 
		while (transition < 1.0f)
		{
			if (!OutOfBounds())
			{
				transform.Translate(Vector3.forward * velocity.value * Time.deltaTime);
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
		transition = 1.0f;
		eventHandler.OnEndTurn();
		Debug.Log("TurnOver");
	}

	// Smooth movement to center of picnic spread
	private IEnumerator MoveToPicnic(float duration)
	{
		float time = 0;
		while (time < duration)
		{
			transform.position = Vector3.MoveTowards(transform.position, gameController.Destination, time / duration);
			time += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		transform.position = gameController.Destination;
	}

	public void PlayerArrived()
	{
		// Call the eventHandle to riase the event.
		eventHandler.OnGameOver();
		transition = 1.0f;
		StopCoroutine(MovePlayer());
		transform.Translate(0, 0, 0);
		// Move to center of picnic spread
		StartCoroutine(MoveToPicnic(2.0f));
		Debug.Log("GameEnd. arrive at picnic");
		eventHandler.OnGameOverReason("You arrived at the picnic.");
	}

}
