using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {

	Text _text;
	int _score = 0;

	// Use this for initialization
	void Start () {
		_text = GetComponent<Text> ();	
		_text.text = "$ " + _score;
	}
	
	// Update is called once per frame
	void IncBy (int value) {
		_score += value;
		_text.text = "$ " + _score;
	}
}
