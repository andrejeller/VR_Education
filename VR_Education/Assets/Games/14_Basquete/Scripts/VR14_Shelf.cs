using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR14_Shelf : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Hand") {
			Debug.Log("Hand In");
			VR14_GameManager.instance.HandOnShelf = true;
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Hand") {
			Debug.Log("Hand Out");
			VR14_GameManager.instance.HandOnShelf = false;
		}
	}
}
