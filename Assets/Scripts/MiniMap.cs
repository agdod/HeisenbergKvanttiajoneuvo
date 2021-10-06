using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
	[Header("Game Components")]
	[SerializeField] private GameObject player;
	[Space]
	[Header("Minimap Components")]
	[SerializeField] private Image mmPlayer;
	[SerializeField] private Image mmDestination;
	[SerializeField] private Image mmTree;
	[SerializeField] [Tooltip("Parent for tree sprite")] private GameObject miniMapPanel; // Parent for tree image on minimap

	private RectTransform rectPlayer;
	private RectTransform rectDestination;

	[SerializeField] private float scaleFactor = 2.5f;

	private void Awake()
	{
		rectPlayer = mmPlayer.GetComponent<RectTransform>();
		rectDestination = mmDestination.GetComponent<RectTransform>();
	}

	private void Start()
	{
		PlayerSetup();
	}

	private void Update()
	{
		UpdatePlayerPosition();
	}

	private void UpdatePlayerPosition()
	{
		float xAxis = player.transform.position.x / scaleFactor;
		float yAxis = player.transform.position.z / scaleFactor;
		rectPlayer.anchoredPosition = new Vector2(xAxis, yAxis);
	}

	private void PlayerSetup()
	{
		float xAxis = 0.0f;
		float yAxis = 0.0f;
		rectPlayer.anchoredPosition = new Vector2(xAxis, yAxis);
	}

	public void AddDestination(Vector3 destination)
	{
		float xAxis = destination.x / scaleFactor;
		float yAxis = destination.z / scaleFactor;
		rectDestination.anchoredPosition = new Vector2(xAxis, yAxis);
	}

	public void AddTree(Vector3 treePosition)
	{
		Image img = Instantiate(mmTree, miniMapPanel.transform);
		float xAxis = treePosition.x / scaleFactor;
		float yAxis = treePosition.z / scaleFactor;
		img.rectTransform.anchoredPosition = new Vector2(xAxis, yAxis);
	}
}
