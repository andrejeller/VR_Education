using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR18_Ponta : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Ground") {
			VR18_GameManager.instance.inWater = true;
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Ground") {
			VR18_GameManager.instance.inWater = false;
		}
	}
}
