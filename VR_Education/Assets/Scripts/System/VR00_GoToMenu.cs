using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class VR00_GoToMenu:MonoBehaviour {
	public static VR00_GoToMenu instance;

	private float timer = 0;
	public GameObject panel;
	public RadialSlider slider;



	private void Awake() {

		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);

		DontDestroyOnLoad(this);
	}

	private void Start() {
		timer = 0;
		panel.SetActive(false);
	}

	void Update() {

		if (OVRInput.GetUp(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.Escape)) {
			ShowPanel();
		}
		if (OVRInput.Get(OVRInput.RawButton.Back) || Input.GetKey(KeyCode.Escape)) {
			timer += Time.deltaTime;
			slider.Angle = Regrade3();

			if (timer > 2.0f)
				LoadMenu();
		}
		if (OVRInput.GetUp(OVRInput.Button.Back) || Input.GetKeyUp(KeyCode.Escape)) {
			timer = 0.0f;
			panel.SetActive(false);
		}
	}

	private void LoadMenu() {
		panel.SetActive(false);
		timer = 0;
		SceneLoader.instance.Load(0);
	}

	private void ShowPanel() {
		panel.SetActive(true);
		Camera camera = Camera.main;
		
		panel.transform.position = (Camera.main.transform.position + (Camera.main.transform.forward * 20));
		panel.transform.LookAt(panel.transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
		//	panel.transform.LookAt(Camera.main.transform.forward);
	}

	private float Regrade3() {
		return ((timer * 360) / 3);
	}
}
