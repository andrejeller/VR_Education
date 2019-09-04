using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR22_PopCorn:MonoBehaviour {

	public GameObject milho;
	public GameObject pipoca;

	float timeInside = 0.0f;

	void Start() {
		pipoca.SetActive(false);
		milho.SetActive(true);
		timeInside = 0.0f;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Fogo") {
			pipoca.SetActive(true);
			milho.SetActive(false);
			//GetComponent<Rigidbody>().AddExplosionForce(2.3f, Vector3.up, 0.5f);
		}
	}

}
