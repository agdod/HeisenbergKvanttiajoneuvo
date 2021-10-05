
using UnityEngine;

[CreateAssetMenu(fileName = "floatVarible", menuName = "Utils/Float Varible")]
public class floatVarible : ScriptableObject
{
	public float value;

	private void OnEnable()
	{
		value = 0.0f;
	}
}
