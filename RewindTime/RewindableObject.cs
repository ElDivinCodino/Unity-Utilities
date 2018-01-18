using UnityEngine;

public class RewindableObject {

	public Vector3 position;
	public Quaternion rotation;

	public RewindableObject (Vector3 _position, Quaternion _rotation) {
		position = _position;
		rotation = _rotation;
	}
}