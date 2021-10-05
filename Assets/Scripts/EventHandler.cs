using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
	public delegate void GameOverReason(string message);
	public delegate void GameOverAction();

	public delegate void CollectUncertainityValues();
	public delegate void TurnAction();

	public static event GameOverReason gameOverReason;
	public static event GameOverAction onGameOver;
	public static event CollectUncertainityValues onCollectUncertainityValues;
	public static event TurnAction onStartTurn;
	public static event TurnAction onEndTurn;
	public static event TurnAction outOfBounds;


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

	public void OnCollectUncertainityValues()
	{
		if (onCollectUncertainityValues != null)
		{
			onCollectUncertainityValues.Invoke();
		}
	}

	public void OnStartTurn()
	{
		if (onStartTurn != null)
		{
			onStartTurn.Invoke();
		}
	}

	public void OnEndTurn()
	{
		if (onEndTurn != null)
		{
			onEndTurn.Invoke();
		}
	}

	public void OnOutOfBounds()
	{
		if (outOfBounds != null)
		{
			outOfBounds.Invoke();
			OnEndTurn();
		}
	}
}
