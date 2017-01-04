using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffPointActivity : MonoBehaviour {

	GameObject _arrow;

	void Start () {
		GetComponent<MeshRenderer> ().enabled = false;
		_arrow = GameObject.FindGameObjectWithTag ("DropOffDirection");
	}

	void Activate(){
		GetComponent<MeshRenderer> ().enabled = true;
		_arrow.SendMessage ("SetTarget", gameObject);
	}
}
