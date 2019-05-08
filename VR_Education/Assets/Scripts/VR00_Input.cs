using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR00_Input:MonoBehaviour {

	private float timer;

	private void Start() {
		timer = 0;
	}

	void Update() {
		if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) {
			SceneLoader.instance.Load(1);
		}
		if (OVRInput.Get(OVRInput.RawButton.Back)) {
			//timer += Time.deltaTime;
			//if (timer > 3.0f)
			SceneLoader.instance.Load(0);
		}
		if (OVRInput.GetUp(OVRInput.Button.Back)) {
			timer = 0.0f;
		}
	}
}
