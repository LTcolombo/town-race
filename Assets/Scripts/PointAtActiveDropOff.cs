using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtActiveDropOff : MonoBehaviour
{
	GameObject _target;

	void SetTarget (GameObject target)
	{
		_target = target;
	}

	void Update ()
	{
		if (_target != null) {
			GetComponent<MeshRenderer> ().enabled = true;
			transform.LookAt (_target.transform.position);
		} else {
			GetComponent<MeshRenderer> ().enabled = false;
		}
	}
}
