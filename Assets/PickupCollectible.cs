using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCollectible : MonoBehaviour
{
	void Start ()
	{
	}

	void OnTriggerEnter (Collider collider)
	{
		foreach (Transform child in transform) {
			if (child.CompareTag ("Collectible")) {
				return;
			}
		}

		if (collider.tag == "Collectible") {
			collider.transform.parent = transform;
			collider.transform.localPosition = new Vector3 (0, 2.08f, -1.9f);
			collider.transform.localRotation = Quaternion.identity;
			Destroy(collider.GetComponent<Rigidbody>());

			collider.GetComponent<DropOffPointReference> ().GetReference ().SendMessage ("Activate");
		}
	}
}
