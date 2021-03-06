using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
	// Define the "Quantum realm into 4 seperate Quads.
	// Place x amount of obsticales in random locations per quadrant.

	// Quadrants :
	//			Q1, Q2
	//			Q3, Q4
	// Q1 = (0, xlowerRange)(0,zUpperRange)
	// Q2 = (0, xUpperRange)(0,ZUpperRange)
	// Q3 = (0, xLowerRange)(0,zLowerRange)
	// Q4 = (0, xUpperRange)(0,zLowerRange)

	[SerializeField] private float xLowerRange;
	[SerializeField] private float xUpperRange;
	[SerializeField] private float zLowerRange;
	[SerializeField] private float zUpperRange;
	[SerializeField] private float yPos;
	[SerializeField] private float zeroPosOffset = 1.5f;

	[SerializeField] private GameObject newParent;

	// Prefer and qauntity 
	[SerializeField] private GameObject spawnablePrefab;
	// Amount of obsticles per Quadrant.
	[SerializeField] private int quantity;
	// Reference to minimap
	[SerializeField] private MiniMap miniMap;


	private void Start()
	{
		SpawnObjects();
	}

	private Vector3 QuadrantPosition(int quad)
	{
		float posx = 0.0f;
		float posz = 0.0f;
		Vector3 posVector = new Vector3(0, 0, 0);

		// Quadrant 1 :
		switch (quad)
		{
			case 1:
				posx = UnityEngine.Random.Range(zeroPosOffset, xLowerRange);
				posz = UnityEngine.Random.Range(zeroPosOffset, zUpperRange);
				posVector = new Vector3(posx, yPos, posz);
				break;
			case 2:
				posx = UnityEngine.Random.Range(zeroPosOffset, xUpperRange);
				posz = UnityEngine.Random.Range(zeroPosOffset, zUpperRange);
				posVector = new Vector3(posx, yPos, posz);
				break;
			case 3:
				posx = UnityEngine.Random.Range(zeroPosOffset, xLowerRange);
				posz = UnityEngine.Random.Range(zeroPosOffset, zLowerRange);
				posVector = new Vector3(posx, yPos, posz);
				break;
			case 4:
				posx = UnityEngine.Random.Range(zeroPosOffset, xUpperRange);
				posz = UnityEngine.Random.Range(zeroPosOffset, zLowerRange);
				posVector = new Vector3(posx, yPos, posz);
				break;
		}
		miniMap.AddTree(posVector);
		return posVector;
	}

	private void SpawnObjects()
	{
		for (int quad = 1; quad < 5; quad++)
		{
			for (int x = 0; x < quantity; x++)
			{
				GameObject go = Instantiate(spawnablePrefab, QuadrantPosition(quad), Quaternion.identity);
				go.transform.parent = newParent.transform;
			}
		}
	}

}
