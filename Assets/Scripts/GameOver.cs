using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	[SerializeField] private EventHandler eventHandler;
	[Space]
	[Header("Game Over elements")]
	[SerializeField] private TMPro.TMP_Text gameoverMessage;
	[SerializeField] private GameObject gameoverCanvas;
	[SerializeField] private GameObject gamePlayCanvas;

	private void Awake()
	{
		EventHandler.gameOverReason += GameOverDisplay;
	}

	public void GameOverDisplay(string message)
	{
		// Stop all movement.
		// Disable all buttons. Enable GameOver Panel - diable over panel.
		// Display message
		// Option to quit try again.
		gamePlayCanvas.SetActive(false);
		gameoverCanvas.SetActive(true);
		gameoverMessage.text = message;

	}

	private void OnDisable()
	{
		EventHandler.gameOverReason -= GameOverDisplay;
	}
}
