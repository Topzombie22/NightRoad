using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTracker : MonoBehaviour
{
	public Transform target;
	public float zOffset = 0.0f;
	public float xOffset = 0.0f;

	void LateUpdate()
	{
		{
			Vector3 position = target.position;
			position.x = target.position.x - 50;
			position.y = target.position.y - 1.15f;
			position.z = target.position.z - 50;
			transform.position = position;
		}
	}
}