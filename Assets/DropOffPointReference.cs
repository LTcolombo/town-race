using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffPointReference : MonoBehaviour {

	GameObject _reference;

	public void SetReference (GameObject value) {
		_reference = value;
	}

	public GameObject GetReference () {
		return _reference;
	}
}
