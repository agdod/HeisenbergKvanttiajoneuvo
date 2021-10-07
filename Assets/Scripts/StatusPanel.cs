using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPanel : MonoBehaviour
{
	[SerializeField] private TMPro.TMP_Text statusMessage;
	[SerializeField] private float duration;
	[SerializeField] private Image image;
	[SerializeField] private float fromImgAlpha = 0.4f;
	[SerializeField] private float fromTextAlpha = 1;
	private Color imgColor;
	private Color textColor;

	private void Awake()
	{
		EventHandler.onStatusUpdate += StatusDisplay;
		Debug.Log("registering fro status updates");
		image = GetComponent<Image>();
		this.gameObject.SetActive(false);
		this.gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		EventHandler.onStatusUpdate -= StatusDisplay;
	}

	private void OnEnable()
	{
		// Set the alpha of the image and text color 
		// Cache the color componet of both image and text
		imgColor = new Color(image.color.r, image.color.g, image.color.b, fromImgAlpha);
		image.color = imgColor;
		textColor = new Color(statusMessage.color.r, statusMessage.color.g, statusMessage.color.b, fromTextAlpha);
		statusMessage.color = textColor;
	}

	private void StatusDisplay(string message)
	{
		this.gameObject.SetActive(true);
		StartCoroutine(DisplayStatusMessage(message));
	}

	private IEnumerator DisplayStatusMessage(string message)
	{
		statusMessage.text = message;

		float time = 0;
		// Fade out Status panle and status text.
		while (time < duration)
		{
			float step = time / duration;
			float imgAlpa = Mathf.Lerp(fromImgAlpha, 0, step);
			image.color = new Color(imgColor.r, imgColor.g, imgColor.b, imgAlpa);
			float textAlpha = Mathf.Lerp(fromTextAlpha, 0, step);
			statusMessage.color = new Color(textColor.r, textColor.b, textColor.g, textAlpha);
			time += Time.deltaTime;
			yield return null;
		}
		this.gameObject.SetActive(false);
	}
}
