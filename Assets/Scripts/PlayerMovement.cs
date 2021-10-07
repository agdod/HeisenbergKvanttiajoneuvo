using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private EventHandler eventHandler;

	[SerializeField] private Vector3 playerStartPosition;
	[SerializeField] private Vector3Variable destination;
	[SerializeField] float transition;
	[SerializeField] private float rotationDuration = 0.5f;
	[SerializeField] [Tooltip("Duration of turn")] private float timeFrame = 5.0f;
	[Space]
	[Header("Uncertainity Values")]
	[SerializeField] private FloatVariable velocity;
	[SerializeField] private FloatVariable direction;
	private bool endTurn;

	public EventHandler EventHandler
	{
		get { return eventHandler; }
	}

	private void Awake()
	{
		EventHandler.onStartTurn += RoateAndMovePlayer;
		EventHandler.onEndTurn += EndTurn;
		EventHandler.outOfBounds += ResetPosition;
	}

	private void OnDisable()
	{
		// unreigster from events
		EventHandler.onStartTurn -= RoateAndMovePlayer;
		EventHandler.onEndTurn -= EndTurn;
		EventHandler.outOfBounds -= ResetPosition;
	}

	private void Start()
	{
		transform.position = playerStartPosition;
	}

	private void EndTurn()
	{
		endTurn = true;
	}

	private void ResetPosition()
	{
		StopAllCoroutines();
		transform.position = playerStartPosition;
	}

	// Rotate the player THEN
	// Move the player.
	public void RoateAndMovePlayer()
	{
		endTurn = false;
		// Target roation is current world space roation PLUS direction roataion.
		Vector3 combinedRoation = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + direction.value, transform.localEulerAngles.z);
		Quaternion targetRoatation = Quaternion.Euler(combinedRoation);
		StartCoroutine(RotatePlayer(targetRoatation, rotationDuration));
		Debug.Log(combinedRoation);
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
		// Only start the movment animation if velcoity is greater than 0
		if (velocity.value > 0)
		{
			eventHandler.InMotion();
		}

		transition = 0f;
		// move the player 
		while (transition < 1.0f && !endTurn)
		{
			transform.Translate(Vector3.forward * velocity.value * Time.deltaTime);
			transition += Time.deltaTime * 1 / timeFrame;
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
			transform.position = Vector3.MoveTowards(transform.position, destination.value, time / duration);
			time += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		transform.position = destination.value;
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
