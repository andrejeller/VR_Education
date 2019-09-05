using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR23_PopCorn:MonoBehaviour {

	public GameObject milho;
	public GameObject pipoca;

	float timeInside = 0.0f;
	private bool boom = false;

	void Start() {
		pipoca.SetActive(false);
		milho.SetActive(true);
		timeInside = 0.0f;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Fogo" && !boom) {
			boom = true;
			pipoca.SetActive(true);
			milho.SetActive(false);
			GetComponent<Rigidbody>().AddForce(Vector3.up * 3, ForceMode.Impulse);
		}
	}

}
