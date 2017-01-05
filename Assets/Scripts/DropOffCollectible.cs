using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffCollectible : MonoBehaviour
{
	GameObject _score;

	void Start ()
	{
		_score = GameObject.FindGameObjectWithTag ("TotalScore");
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.CompareTag ("DropOff")) {
			foreach (Transform child in transform) {
				if (child.CompareTag ("Collectible")) {
					if (child.name == collider.name) {
						Destroy (child.gameObject);
						Destroy (collider.gameObject);
						_score.SendMessage ("IncBy", 20);
						return;
					}
				}
			}
		}
	}
}
