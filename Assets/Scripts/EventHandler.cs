using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
	public delegate void GameOverReason(string message);
	public delegate void GameOverAction();

	public static event GameOverReason gameOverReason;
	public static event GameOverAction onGameOver;



	public void OnGameOverReason(string message)
	{
		OnGameOver();

		if (gameOverReason != null)
		{
			gameOverReason.Invoke(message);
		}
	}

	public void OnGameOver()
	{
		if (onGameOver != null)
		{
			onGameOver.Invoke();
		}
	}
}
