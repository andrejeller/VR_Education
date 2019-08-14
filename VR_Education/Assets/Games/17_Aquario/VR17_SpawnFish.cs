using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class VR17_SpawnFish : MonoBehaviour {


	public GameObject fishPrefab;
	int size = 150;

	void Start () {
		for (int i = 0; i < size; i++) {
			Instantiate(fishPrefab, new Vector3(Random.Range(-80, 80), Random.Range(2, 20), Random.Range(-80, 80)), Quaternion.identity, transform)
				.GetComponent<VR17_Fish>().pathCreator = transform.GetComponent<PathCreator>();
		}
	}
	
	
}
