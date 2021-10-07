using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerStand : MonoBehaviour
{
	[SerializeField] private float duration;
	[SerializeField] private Renderer[] renderers;
	[SerializeField] private List<Material> materials = new List<Material>();

	private void Awake()
	{
		renderers = GetComponentsInChildren<Renderer>();
		EventHandler.onStartTurn += StartFade;
	}

	private void Start()
	{
		// Cache the materails 
		foreach (Renderer renderer in renderers)
		{
			// If more than one mateail in the Render
			// Extract each materail from the Render and add to the materails List.
			Material[] mats = renderer.materials;
			foreach (Material mat in mats)
			{
				materials.Add(mat);
			}
		}
	}

	private void OnDisable()
	{
		EventHandler.onStartTurn -= StartFade;
	}

	private void StartFade()
	{
		StartCoroutine(Fade());
	}

	IEnumerator Fade()
	{
		float time = 0;
		float fadeFrom = 1;
		Debug.Log("alpha value : " + fadeFrom);
		float alpha;
		while (time < duration)
		{
			alpha = Mathf.Lerp(fadeFrom, 0, time / duration);
			// Cycle through all materails in Mesh Renderer
			for (int x = 0; x < materials.Count; x++)
			{
				Color thisColor = materials[x].color;
				materials[x].color = new Color(thisColor.r, thisColor.g, thisColor.b, alpha);
			}
			time += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}

		gameObject.SetActive(false);
	}
}
