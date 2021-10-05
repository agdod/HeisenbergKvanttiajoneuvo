using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	[Header("Event Handler and other Controllers")]
	[SerializeField] private EventHandler eventHandler;
	[Space]
	[SerializeField] private GameObject destination;
	[SerializeField] private Vector3 destinationPosition;
	[SerializeField] private GameObject flowerStand;

	[SerializeField] private TMPro.TMP_Text remainTurnsText;

	[Header("Quantum Reealm diamensions")]
	[SerializeField] private float xValue = 230.0f;
	[SerializeField] private float zValue = 230.0f;
	[SerializeField] private float yOffset;

	//[SerializeField] private GameObject centerPanel;

	[SerializeField] private int remainingTurns = 5;

	[SerializeField] [Tooltip("Duration of turn")] private float timeFrame = 5.0f;
	[SerializeField] private bool gameOver = false;

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
		EventHandler.onGameOver += OnGameOverAction;
		EventHandler.onEndTurn += EndTurn;
	}

	private void OnDisable()
	{
		// unregister from events
		EventHandler.onGameOver += OnGameOverAction;
		EventHandler.onEndTurn -= EndTurn;
	}

	private void Start()
	{
		if (destination != null)
		{
			PositionDestination();
		}
		remainTurnsText.text = remainingTurns.ToString();
		GenerateRandomSeed();
	}

	public void EndTurn()
	{
		remainingTurns--;
		remainTurnsText.text = remainingTurns.ToString();
		if (remainingTurns < 1 && !gameOver)
		{
			Debug.Log("GameOver out of turns");
			eventHandler.OnGameOverReason("Out of turns.");
		}
	}

	private void PositionDestination()
	{
		GenerateRandomSeed();
		float xpos = UnityEngine.Random.Range(-xValue, xValue);
		float zpos = UnityEngine.Random.Range(-zValue, zValue);
		destinationPosition = new Vector3(xpos, yOffset, zpos);
		Instantiate(destination, destinationPosition, Quaternion.identity);
	}

	private void GenerateRandomSeed()
	{
		// Cast int64 DateTimeNow.Ticks to a int32 
		int initalSeed = (int)DateTime.Now.Ticks;
		UnityEngine.Random.InitState(initalSeed);
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

	private void OnGameOverAction()
	{
		gameOver = true;
	}
}
