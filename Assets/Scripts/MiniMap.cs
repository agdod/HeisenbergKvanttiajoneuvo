using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    [Header("Game Components")]
	[SerializeField] private GameController gameController;
    [SerializeField] private GameObject player;

	[Header("Minimap Components")]
	[SerializeField] private Image mmPlayer;
	[SerializeField] private Image mmDestination;

	private RectTransform rectPlayer;
	private RectTransform rectDestination;

	private float scaleFactor=2.5f;

	private void Awake()
	{
		rectPlayer = mmPlayer.GetComponent<RectTransform>();
		rectDestination = mmDestination.GetComponent<RectTransform>();
	}

	IEnumerator Start()
	{
		// Slight delay to make sure everything is load before fitting it to minimap
		yield return new WaitForSeconds(0.1f);
		MiniMapSetup();
	}

	private void MiniMapSetup()
	{
		float xAxis = 0.0f;
		float yAxis = 0.0f;
		Debug.Log(mmPlayer.transform.position);
		rectPlayer.position = new Vector2(xAxis,yAxis);

	}
}
