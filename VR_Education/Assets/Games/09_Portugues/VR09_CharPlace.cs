using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR09_CharPlace:MonoBehaviour {

	public char myChar;
	private Renderer myMaterial;
	private GameObject myObj;
	bool certinho = false;

	private void Start() {
		myMaterial = GetComponent<Renderer>();
	}

	public void ResetPlace() {
		certinho = false;
		myObj = null;
		myMaterial.material.color = Color.white;
	}

	private void OnTriggerEnter(Collider other) {
		if (certinho) return;

		if (other.gameObject.GetComponent<VR09_CharBlock>().myChar == myChar) {
			myMaterial.material.color = Color.green;
			myObj = other.gameObject;
			certinho = true;
			VR09_GameManager.instance.CardIn(true);
		}
		else {
			certinho = false;
			myMaterial.material.color = Color.red;
		}
	}

	private void OnTriggerExit(Collider other) {

		if (!certinho) {
			myMaterial.material.color = Color.white;
			return;
		}
		if (other.gameObject != myObj) return;

		myMaterial.material.color = Color.white;
		VR09_GameManager.instance.CardIn(false);
		certinho = false;
	}

}
