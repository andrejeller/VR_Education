using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR14_Ball:MonoBehaviour {


	public Rigidbody body;

	void Update() {
		transform.Rotate(1, 1, 0);
		if (body.useGravity) body.AddForce(Vector3.down * 100, ForceMode.Acceleration);
	}


}
