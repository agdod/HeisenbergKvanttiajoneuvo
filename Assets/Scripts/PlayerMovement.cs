using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	[SerializeField] private GameObject player;

	// User input values
	[SerializeField] private float velocity;
	[SerializeField] private float direction;
	private Vector3 playerDirection = new Vector3(0, 0, 0);
	[SerializeField] private Vector3 playerStartPosition;
	[SerializeField] private GameController gameController;
	[SerializeField] float transition;

	void Awake()
	{

	}

	private void Start()
	{
		transform.position = playerStartPosition;
	}

	void Update()
	{
		//StartCoroutine(MovePlayer());
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

	public IEnumerator MovePlayer(float pVelocity, float pDirection)
	{
		// rotate the player direction
		transform.Rotate(0, pDirection, 0);
		transition = 0f;

		// move the player 
		gameController.StartTurn();
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
	public void OnTriggerEnter(Collider other)
	{
		Debug.Log(this.name + " collided wiht " + other);
	}
}
