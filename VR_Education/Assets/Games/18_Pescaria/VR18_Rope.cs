using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR18_Rope : MonoBehaviour {

	private void Start() {
		GetComponent<CharacterJoint>().connectedBody = transform.parent.GetComponent<Rigidbody>();
	}

	private void Update() {

	}
}
