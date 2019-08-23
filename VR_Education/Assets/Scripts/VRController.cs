using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRController:MonoBehaviour {


	public GameObject touch;

	void Update() {

		float x = VRInput.Axes().x;
		float y = VRInput.Axes().y;

		if (x != 0.0f && y != 0.0f) {
			x += 1; y += 1;
			x = Mathf.Lerp(-0.045f, 0.045f, x / 2);
			//y = Mathf.Lerp(-0.045f, 0.045f, y / 2);
		}
	}
}
