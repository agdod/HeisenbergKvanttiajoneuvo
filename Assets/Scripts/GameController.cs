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
	[SerializeField] private float velocity;

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

	private float CollectDirection()
	{
		if (directionText.isActiveAndEnabled)
		{
			try
			{
				float dir = float.Parse(directionText.text);
				return dir;
			}
			catch (FormatException e)
			{
				Debug.LogError(e.Message);
			}
		}
		// else random generate dirrection
		return 0.0f;
	}

	private float CollectVelocity()
	{
		if (velocityText.isActiveAndEnabled)
		{
			try
			{
				int vel = Int32.Parse(velocityText.text);
				return vel;
			}
			catch (FormatException e)
			{
				Debug.LogError(e.Message);
			}

		}
		// else random generate velocity
		return 0.0f;
	}
}
