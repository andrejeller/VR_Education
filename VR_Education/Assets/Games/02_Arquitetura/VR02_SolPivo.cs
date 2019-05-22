using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR02_SolPivo:MonoBehaviour {

	public GameObject DirectionalLight;

	//Drag&Drop
	public void Update1(Transform to) {



		float distance = Vector3.Distance(transform.position, to.position);
		Vector3 dist = to.position + (to.forward * distance);


		transform.LookAt(new Vector3(dist.x, dist.y, dist.z));
		//transform.localRotation = Quaternion.Euler(to.rotation.x, 45, 0);
		DirectionalLight.transform.rotation = Quaternion.Euler(dist.x, -90.0f, 0);
	}

	//Touch
	public void Update2() {

		Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

		if (input.x == 0) return;
		
		input.x += 1;
		float lerp = Mathf.Lerp(10.0f, 170.0f, input.x / 2.0f);

		transform.localRotation = Quaternion.Euler(lerp, 45.0f, transform.rotation.z);
		DirectionalLight.transform.rotation = Quaternion.Euler(lerp, 90.0f, 0);
	}

}
