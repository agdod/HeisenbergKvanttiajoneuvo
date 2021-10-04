using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UncertainityPanel : MonoBehaviour
{
	public enum Uncertainity { velocity, direction }

	[SerializeField] private Toggle thisToggle;
	[SerializeField] private Slider thisSlider;
	[SerializeField] private TMPro.TMP_Text thisValue;
	[SerializeField] private Uncertainity uncertainity;

	private void Start()
	{
		ActivateSlider();
	}

	public void ActivateSlider()
	{
		if (thisToggle.isOn)
		{
			thisSlider.gameObject.SetActive(true);
		}
		else
		{
			thisSlider.gameObject.SetActive(false);
		}
	}

	public void AdjustThisValue()
	{
		thisValue.text = thisSlider.value.ToString();
	}

}
