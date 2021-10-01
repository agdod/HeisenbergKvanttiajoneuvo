using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePanels : MonoBehaviour
{
	public enum Scaler { velocity,direction}
	
	[SerializeField] private GameObject velocityInputText;
	[SerializeField] private GameObject velocityPanleMask;
	[SerializeField] private GameObject dirrectionInputText;
	[SerializeField] private GameObject dirrectionPanelMask;
	[SerializeField] private Scaler thisScaler;

	public void ActivateVelocityPanel()
	{
		velocityInputText.SetActive(true);
		velocityPanleMask.SetActive(false);
		dirrectionInputText.SetActive(false);
		dirrectionPanelMask.SetActive(true);
	}

	public void ActivateDirrectionPanel()
	{
		velocityInputText.SetActive(false);
		velocityPanleMask.SetActive(true);
		dirrectionInputText.SetActive(true);
		dirrectionPanelMask.SetActive(false);
	}

}
