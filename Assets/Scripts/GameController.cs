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

	[SerializeField] private TMPro.TMP_Text remainTurnsText;

	[SerializeField] private int remainingTurns = 5;

	[SerializeField] private bool gameOver = false;

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
		remainTurnsText.text = remainingTurns.ToString();
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

	public void Quit()
	{
		Debug.Log("Quit pressed.");
		Application.Quit();
	}

	public void PlayAgain()
	{
		SceneManager.LoadScene("GamePlay");
	}

	private void OnGameOverAction()
	{
		gameOver = true;
	}
}
