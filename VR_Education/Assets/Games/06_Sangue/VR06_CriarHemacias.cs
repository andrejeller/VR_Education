using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;


public class VR06_CriarHemacias:MonoBehaviour {


	public GameObject hemacia;

	void Start() {
		for (int i = 0; i < 100; i++) {
			Instantiate(hemacia, new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f), Random.Range(-53, 53)), Quaternion.identity, transform)
				.GetComponent<VR06_Hemacia>().pathCreator = transform.GetComponent<PathCreator>();
		}
	}
}
