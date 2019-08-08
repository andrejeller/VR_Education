using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR07_GenerateFakeFluid : MonoBehaviour {


	public GameObject prefab;

	private float time;

	void Start () {
		time = Time.time;	
	}
	
	void Update () {

		

	}


	public void Create() {
		if (Time.time - time > 0.03f) {
			Instantiate(prefab, transform.position, Quaternion.identity, transform);
			time = Time.time;
		}
	}

}
