using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class VR00_GoToMenu:MonoBehaviour {


	private float timer = 0;
	public GameObject panel;
	public RadialSlider slider;

	private void Awake() {
		DontDestroyOnLoad(this);
	}

	private void Start() {
		timer = 0;
		panel.SetActive(false);
	}

	void Update() {

		if (OVRInput.GetUp(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.Escape))
			panel.SetActive(true);

		if (OVRInput.Get(OVRInput.RawButton.Back) || Input.GetKey(KeyCode.Escape)) {
			timer += Time.deltaTime;
			slider.Angle = Regrade3();

			if (timer > 3.0f)
				SceneLoader.instance.Load(0);
		}
		if (OVRInput.GetUp(OVRInput.Button.Back) || Input.GetKeyUp(KeyCode.Escape)) {
			timer = 0.0f;
			panel.SetActive(false);
		}
	}


	private float Regrade3() {
		return ((timer * 360) / 3);
	}
}
