using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR20_Arrow : MonoBehaviour {

	public Rigidbody body;

	void Update() {
		if (body.useGravity) body.AddForce(Vector3.down * 100, ForceMode.Acceleration);
	}
}
