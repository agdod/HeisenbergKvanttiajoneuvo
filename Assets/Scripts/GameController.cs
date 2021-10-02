using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
	[SerializeField] private GameObject player;
	[SerializeField] private PlayerMovement playerMovement;

	[SerializeField] private float direction;
	[SerializeField] private float directionLowerRange;
	[SerializeField] private float directionUpperRange;

	[SerializeField] private float velocity;
	[SerializeField] private float velocityLowerRange;
	[SerializeField] private float velocityUpperRange;

	[SerializeField] private Text velocityText;
	[SerializeField] private Text directionText;

	[SerializeField] [Tooltip("Duration of turn")] private float timeFrame = 5.0f;

	public float TimeFrame
	{
		get { return timeFrame; }
	}

	private void Awake()
	{
		playerMovement = player.GetComponent<PlayerMovement>();
	}

	public void CollectValues()
	{
		direction = CollectDirection();
		velocity = CollectVelocity();
		StartCoroutine(playerMovement.MovePlayer(velocity, direction));
	}

	private void GenerateRandomSeed()
	{
		int initalSeed = (int)Time.deltaTime;
		UnityEngine.Random.InitState(initalSeed);
	}

	private float CollectDirection()
	{
		float dir = 0.0f;
		if (directionText.isActiveAndEnabled)
		{
			try
			{
				dir = float.Parse(directionText.text);
			}
			catch (FormatException e)
			{
				Debug.LogError(e.Message);
			}
		}
		// else random generate dirrection
		else
		{
			Debug.Log("Generating random direction.");
			GenerateRandomSeed();
			dir = UnityEngine.Random.Range(directionLowerRange, directionUpperRange);
		}
		return dir;
	}

	private float CollectVelocity()
	{
		float vel = 0.0f;
		if (velocityText.isActiveAndEnabled)
		{
			try
			{
				vel = float.Parse(velocityText.text);
			}
			catch (FormatException e)
			{
				Debug.LogError(e.Message);
			}

		}
		// else random generate velocity
		else
		{
			Debug.Log("generating random velocity.");
			GenerateRandomSeed();
			vel = UnityEngine.Random.Range(velocityLowerRange, velocityUpperRange);
		}
		return vel;
	}
}
