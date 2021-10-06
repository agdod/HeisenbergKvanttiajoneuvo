using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoButton : MonoBehaviour
{
	[SerializeField] private EventHandler eventHandler;
	[SerializeField] private Button goButton;

	private void Awake()
	{
		EventHandler.onEndTurn += OnResetAndEnable;
	}

	private void OnDisable()
	{
		EventHandler.onEndTurn -= OnResetAndEnable;
	}

	public void OnClickGo()
	{
		eventHandler.OnCollectUncertainityValues();
		eventHandler.OnStartTurn();
	}

	private void OnResetAndEnable()
	{
		goButton.interactable = true;
	}

}
