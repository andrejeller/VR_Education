using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR09_CharPlace:MonoBehaviour {

	public char myChar;
	private Renderer myMaterial;

	private void Start() {
		myMaterial = GetComponent<Renderer>();
	}

	private void OnTriggerStay(Collider other) {

		if (other.gameObject.GetComponent<VR09_CharBlock>().myChar == myChar)
			myMaterial.material.color = Color.green;
		else
			myMaterial.material.color = Color.red;

	}

	private void OnTriggerExit(Collider other) {
		myMaterial.material.color = Color.white;
	}

}
