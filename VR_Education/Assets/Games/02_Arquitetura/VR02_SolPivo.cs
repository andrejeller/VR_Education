using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR02_SolPivo:MonoBehaviour {

	public GameObject DirectionalLight;

	//Drag&Drop
	public void Update1(Vector3 lookAt) {

		if (lookAt.y < 0) return;

		transform.LookAt(new Vector3(-lookAt.x, -lookAt.y, transform.position.z));
	}

	//Touch
	public void Update2() {

		Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

		if (input.x == 0) return;

		input.x += 1;
		float lerp = Mathf.Lerp(10.0f, 170.0f, input.x / 2.0f);

		transform.localRotation = Quaternion.Euler(lerp, 45.0f, transform.rotation.eulerAngles.z);
	}

}
