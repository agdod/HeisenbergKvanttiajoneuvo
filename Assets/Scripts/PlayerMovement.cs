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

	[SerializeField] private GameController gameController;

	void Awake()
	{

	}


	void Update()
	{
		//StartCoroutine(MovePlayer());
	}

	public IEnumerator MovePlayer(float pVelocity, float pDirection)
	{
		// rotate the player direction
		transform.Rotate(0, pDirection, 0);
		float transition;
		transition = 0f;

		// move the player 
		while (transition < 1.0f)
		{
			transform.Translate(Vector3.forward * pVelocity * Time.deltaTime);
			transition += Time.deltaTime * 1 / gameController.TimeFrame;
			Debug.Log(transition);
			yield return new WaitForEndOfFrame();
		}

		Debug.Log("TurnOver");
	}
}
