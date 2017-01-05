using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerCenterOfMass : MonoBehaviour {

	public Vector3 delta;

	void Start() {
		GetComponent<Rigidbody> ().centerOfMass -= delta;
	}
}
