using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	float enginePower = 450.0f;
	float maxSteer = 12.0f;

	WheelCollider _frontLeft;
	WheelCollider _frontRight;
	WheelCollider _rearLeft;
	WheelCollider _rearRight;

	WheelCollider[] _colliders;

	// Use this for initialization
	void Start ()
	{
		var colliders = transform.Find ("wheels").transform;
		_frontLeft = colliders.Find ("fl").GetComponent <WheelCollider> ();
		_frontRight = colliders.Find ("fr").GetComponent <WheelCollider> ();
		_rearLeft = colliders.Find ("rl").GetComponent <WheelCollider> ();
		_rearRight = colliders.Find ("rr").GetComponent <WheelCollider> ();

		_colliders = new WheelCollider[4] {
			_frontLeft,
			_frontRight,
			_rearLeft,
			_rearRight
		};
	}
	
	// Update is called once per frame
	void Update ()
	{
		float power = Input.GetAxis ("Vertical") * enginePower;
		float steer = Input.GetAxis ("Horizontal") * maxSteer;
		float brake = Input.GetKey ("space") ? 1000f : 0f;

		_frontLeft.steerAngle = steer;
		_frontRight.steerAngle = steer;

		if (brake > 0.0) {
			_rearLeft.brakeTorque = brake;
			_rearRight.brakeTorque = brake;
			_frontLeft.motorTorque = 0.0f;
			_frontLeft.motorTorque = 0.0f;
		} else {
			_rearLeft.brakeTorque = 0;
			_rearRight.brakeTorque = 0;
			_frontLeft.motorTorque = power;
			_frontRight.motorTorque = power;
		}

		foreach (WheelCollider collider in _colliders){
			if (collider.transform.childCount == 0) {
				Debug.LogWarning("No collider attached to wheel: " + collider.name);
				return;
			}

			Transform geometry = collider.transform.FindChild("geometry");

			Vector3 position;
			Quaternion rotation;
			collider.GetWorldPose(out position, out rotation);

			geometry.position = position;
			geometry.rotation = rotation;
		}
	}
}
