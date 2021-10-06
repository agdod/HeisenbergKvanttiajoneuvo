
using UnityEngine;

[CreateAssetMenu(fileName = "floatVariable", menuName = "Utils/Float Variable")]
public class FloatVariable : ScriptableObject
{
	public float value;

	private void OnEnable()
	{
		value = 0.0f;
	}
}
