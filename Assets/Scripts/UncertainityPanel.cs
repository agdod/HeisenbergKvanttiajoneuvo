using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public enum Uncertainity { velocity, direction }

public class UncertainityPanel : MonoBehaviour
{
	[Header("Identifier")]
	[SerializeField] private Uncertainity uncertainity;
	[Space]
	[SerializeField] private Toggle thisToggle;
	[SerializeField] private Slider thisSlider;
	[SerializeField] private TMPro.TMP_Text thisValue;
	[SerializeField] private floatVarible uncertaintyVariable;

	private void Awake()
	{
		EventHandler.onCollectUncertainityValues += GenerateThisValue;
		EventHandler.onStartTurn += DisableAll;
		EventHandler.onEndTurn += EnableAndReset;
	}

	private void OnDisable()
	{
		EventHandler.onCollectUncertainityValues -= GenerateThisValue;
		EventHandler.onStartTurn -= DisableAll;
		EventHandler.onEndTurn -= EnableAndReset;
	}

	private void Start()
	{
		ActivateSlider();
	}

	public void ActivateSlider()
	{
		if (thisToggle.isOn)
		{
			thisSlider.gameObject.SetActive(true);
			thisValue.text = thisSlider.value.ToString();
		}
		else
		{
			thisSlider.gameObject.SetActive(false);
			thisValue.text = "###";

		}
	}

	public void AdjustThisValue()
	{
		thisValue.text = thisSlider.value.ToString();
	}

	private void GenerateThisValue()
	{
		if (thisToggle.isOn)
		{
			// thisSlider.value
			uncertaintyVariable.value = thisSlider.value;
		}
		else
		{
			thisSlider.value = 0;
			/*thisSlider.gameObject.SetActive(false);
			thisValue.text = "###";*/
			// Generate random value
			GenerateRandomValue();
		}
	}

	private void GenerateRandomValue()
	{
		// Random seed value
		int initalSeed = (int)DateTime.Now.Ticks;
		UnityEngine.Random.InitState(initalSeed);
		// random value, between min and max of slider values.
		uncertaintyVariable.value = UnityEngine.Random.Range(thisSlider.minValue, thisSlider.maxValue);
	}

	private void DisableAll()
	{
		thisSlider.interactable = false;
		thisToggle.interactable = false;
	}

	private void EnableAndReset()
	{
		thisSlider.interactable = true;
		thisSlider.value = 0;
		AdjustThisValue();
		thisToggle.interactable = true;
	}
}
