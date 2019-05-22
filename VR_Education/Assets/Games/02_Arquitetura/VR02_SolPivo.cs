using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR02_SolPivo:MonoBehaviour {

	public GameObject DirectionalLight;
	public GameObject sol;
	
	public void Update() {

		Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

		if (input.x == 0) return;
		
		input.x += 1;
		float lerp = Mathf.Lerp(10.0f, 170.0f, input.x / 2.0f);

		transform.localRotation = Quaternion.Euler(lerp, 45.0f, transform.rotation.z);
		DirectionalLight.transform.rotation = Quaternion.Euler(lerp, 90.0f, 0);
	}

}
