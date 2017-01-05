using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Delivery
{
	public GameObject collectible;
	public GameObject dropOffPoint;
}

public class SpawnDelivery : MonoBehaviour
{
	public Vector3 offset;
	public Delivery delivery;
	public float interval = 20;

	float _accumulated;
	int _id;

	// Use this for initialization
	void Start ()
	{
		_id = 0;
		_accumulated = 0;
		Spawn ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		_accumulated += Time.deltaTime;
		while (_accumulated > interval) {
			_accumulated -= interval;
			_id++;
			Spawn ();
		}
	}

	void Spawn ()
	{
		var deliveryId = name + "_delivery_" + _id;

		var collectible = Instantiate (delivery.collectible, transform.position + offset, Quaternion.identity);
		collectible.name = deliveryId;

		var position = new Vector3 (67 * Random.Range (1, 6), 0, -67 * Random.Range (1, 4));
		var dropOff = Instantiate (delivery.dropOffPoint, position, Quaternion.identity);
		dropOff.name = deliveryId;

		collectible.GetComponent<DropOffPointReference> ().SetReference (dropOff);
	}
}
