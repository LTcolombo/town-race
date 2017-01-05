using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
	public Transform target;
	public float distance;

	public float height = 3.0f;
	public float damping = 5.0f;
	public float rotationDamping = 10.0f;

	void Update () {
		Vector3 wantedPosition = target.TransformPoint(0, height, -distance);
		transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);

		Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
		transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
	}
}
