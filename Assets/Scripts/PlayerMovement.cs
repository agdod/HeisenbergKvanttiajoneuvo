using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	[SerializeField] private GameObject player;
	[SerializeField] private GameObject velocityPanel;
	[SerializeField] private GameObject directionPanel;

	// User input values
	[SerializeField] [Range(0, 100)] private float velocity;
	[SerializeField] [Range(0, 360)] private float direction;
	private Vector3 playerDirection = new Vector3(0, 0, 0);
	[SerializeField][Tooltip("Duration of turn")] private float timeFrame = 5.0f;

	void Start()
	{
		StartCoroutine(MovePlayer());
	}


	void Update()
	{
		//StartCoroutine(MovePlayer());
	}

	private void CollectDirection()
	{

	}

	private void CollectVelocity()
	{

	}

	// will need velocity and dirrection passed into as parameters.
	IEnumerator MovePlayer()
	{
		// direction
		// distance = Velocity  * time;
		// Velocity 

		// rotate the player direction
		player.transform.Rotate(0, 0, direction);
		float transition;
		transition = 0f;

		// move the player 
		while (transition < 1.0f)
		{
			player.transform.Translate(Vector3.up * velocity * Time.deltaTime);
			transition += Time.deltaTime * 1 / timeFrame;
			Debug.Log(transition);
			yield return new WaitForEndOfFrame();
		}

		Debug.Log("TurnOver");
	}
}
