using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{

	[SerializeField] private GameObject player;
	[SerializeField] private GameObject velocityPanel;
	[SerializeField] private GameObject directionPanel;
	[SerializeField] private TMPro.TMP_Text velocityText;
	[SerializeField] private TMPro.TMP_Text directionText;

	// User input values
	[SerializeField] [Range(0, 100)] private float velocity;
	[SerializeField] [Range(0, 360)] private float direction;
	private Vector3 playerDirection = new Vector3(0, 0, 0);
	[SerializeField] [Tooltip("Duration of turn")] private float timeFrame = 5.0f;

	void Start()
	{

	}


	void Update()
	{
		//StartCoroutine(MovePlayer());
	}

	public void CollectValues()
	{
		direction = CollectDirection();
		velocity = CollectVelocity();
		StartCoroutine(MovePlayer(velocity, direction));
	}

	private float CollectDirection()
	{
		if (directionText.isActiveAndEnabled)
		{
			Debug.Log("dirrection " + directionText.text);
			string dirText = directionText.text.ToString();
			try
			{
				float dir = float.Parse(dirText);
				return dir;
			} catch (FormatException e)
			{
				Debug.Log(e.Message + " "+dirText);
			}
		}
		// else random generate dirrection
		return 0.0f;
	}

	private float CollectVelocity()
	{
		if (velocityText.isActiveAndEnabled)
		{
			int vel = Int32.Parse(velocityText.text);
			return vel;
		}
		// else random generate velocity
		Debug.Log("random velcoity");
		return 0.0f;
	}

	// will need velocity and dirrection passed into as parameters.
	IEnumerator MovePlayer(float pVelocity, float pDirection)
	{
		// direction
		// distance = Velocity  * time;
		// Velocity 

		// rotate the player direction
		player.transform.Rotate(0, 0, pDirection);
		float transition;
		transition = 0f;

		// move the player 
		while (transition < 1.0f)
		{
			player.transform.Translate(Vector3.up * pVelocity * Time.deltaTime);
			transition += Time.deltaTime * 1 / timeFrame;
			Debug.Log(transition);
			yield return new WaitForEndOfFrame();
		}

		Debug.Log("TurnOver");
	}
}
