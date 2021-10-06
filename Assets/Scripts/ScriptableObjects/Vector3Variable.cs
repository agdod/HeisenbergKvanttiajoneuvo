
using UnityEngine;

[CreateAssetMenu(fileName = "Vector3Variable", menuName = "Utils/Vector3Variable")]
public class Vector3Variable : ScriptableObject
{
	public Vector3 value;

	private void OnEnable()
	{
		value = new Vector3(0, 0, 0);
	}
}
