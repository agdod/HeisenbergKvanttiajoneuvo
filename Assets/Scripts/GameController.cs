using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	[SerializeField] private GameObject player;
	[SerializeField] private PlayerMovement playerMovement;
	[SerializeField] private GameObject destination;
	[SerializeField] private Vector3 destinationPosition;
	[SerializeField] private ArrowToPicnic arrowToPicnic;
	[SerializeField] private GameObject flowerStand;


	[SerializeField] private float direction;
	[SerializeField] private float directionLowerRange;
	[SerializeField] private float directionUpperRange;

	[SerializeField] private float velocity;
	[SerializeField] private float velocityLowerRange;
	[SerializeField] private float velocityUpperRange;

	[SerializeField] private Text velocityText;
	[SerializeField] private Text directionText;
	[SerializeField] private TMPro.TMP_Text remainTurnsText;

	[Header("Game Over elements")]
	[SerializeField] private TMPro.TMP_Text gameoverMessage;
	[SerializeField] private GameObject gameoverCanvas;
	[SerializeField] private GameObject gamePlayCanvas;

	[Header("Quantum Reealm diamensions")]
	[SerializeField] private float xValue = 230.0f;
	[SerializeField] private float zValue = 230.0f;
	[SerializeField] private float yOffset;

	[SerializeField] private GameObject centerPanel;

	[SerializeField] private int remainingTurns = 5;

	[SerializeField] [Tooltip("Duration of turn")] private float timeFrame = 5.0f;
	[SerializeField] private bool gameEnd = false;

	public Vector3 Destination
	{
		get { return destinationPosition; }
	}

	public float TimeFrame
	{
		get { return timeFrame; }
	}

	private void Awake()
	{
		playerMovement = player.GetComponent<PlayerMovement>();
	}

	private void Start()
	{
		if (destination != null)
		{
			PositionDestination();
		}
		remainTurnsText.text = remainingTurns.ToString();
	}

	public void StartTurn()
	{
		centerPanel.SetActive(true);
	}

	public void EndTurn()
	{
		centerPanel.SetActive(false);
		//arrowToPicnic.UpdateArrow();
		remainingTurns--;
		remainTurnsText.text = remainingTurns.ToString();
		if (remainingTurns < 1)
		{
			Debug.Log("GameOver");
			GameOver(" Out of turns. ");
		}
	}

	public void GameOver(string message)
	{
		// Stop all movement.
		// Disable all buttons. Enable GameOver Panel - diable over panel.
		// Display message
		// Option to quit try again.
		gamePlayCanvas.SetActive(false);
		gameoverCanvas.SetActive(true);
		gameoverMessage.text = message;

	}

	public void CollectValues()
	{
		direction = CollectDirection();
		velocity = CollectVelocity();
		StartCoroutine(disableFlowerStand());
		playerMovement.RoateAndMovePlayer(velocity, direction);
	}

	private void PositionDestination()
	{
		float xpos = UnityEngine.Random.Range(-xValue, xValue);
		float zpos = UnityEngine.Random.Range(-zValue, zValue);
		destinationPosition = new Vector3(xpos, yOffset, zpos);
		Instantiate(destination, destinationPosition, Quaternion.identity);
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
		dir = Mathf.Clamp(dir, 0, 360);
		Debug.Log(dir);
		directionText.text = dir.ToString();
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
		vel = Mathf.Clamp(vel, 0, 25.0f);
		Debug.Log(vel);
		velocityText.text = vel.ToString();
		return vel;
	}

	public void Quit()
	{
		Debug.Log("Quit pressed.");
		Application.Quit();
	}

	public void PlayAgain()
	{
		SceneManager.LoadScene("GamePlay");
	}

	IEnumerator disableFlowerStand()
	{
		yield return new WaitForSeconds(1.5f);
		flowerStand.SetActive(false);
	}

}
