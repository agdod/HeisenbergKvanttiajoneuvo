using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
	[SerializeField] private Animator animator;

	private void Awake()
	{
		EventHandler.onEndTurn += Stopped;
		EventHandler.inMotion += InMotion;
	}

	private void OnDisable()
	{
		EventHandler.onEndTurn -= Stopped;
		EventHandler.inMotion -= InMotion;
	}

	private void InMotion()
	{
		animator.SetBool("inMotion", true);
	}

	private void Stopped()
	{
		animator.SetBool("inMotion", false);
	}
}
