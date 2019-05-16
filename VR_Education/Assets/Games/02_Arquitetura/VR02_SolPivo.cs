using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR02_SolPivo:MonoBehaviour {

	public GameObject DirectionalLight;
	private Vector3 lastRotation;

	private bool isHolding = false;

	public Camera cam;

	private void Start() {
		lastRotation = transform.rotation.eulerAngles;
		isHolding = false;
	}


	private void Update() {
		UpdateSol(Vector3.zero);
		//transform.LookAt(Camera.main.ViewportToWorldPoint(Input.mousePosition));
	}

	public void UpdateSol(Vector3 inputPosition) {
		//if (!isHolding) return;



		//OVRInput.Controller.


		transform.LookAt(Camera.main.ViewportToWorldPoint(Input.mousePosition));


		//if (transform.localRotation.z < 180 && Input.GetKeyDown(KeyCode.A))
			//transform.Rotate(new Vector3(0, 0, 2.0f));

		//if (transform.localRotation.z > 0 && Input.GetKeyDown(KeyCode.D))
			//transform.Rotate(new Vector3(0, 0, -2.0f));


		if (lastRotation != transform.rotation.eulerAngles) {
			DirectionalLight.transform.DORotate(new Vector3(transform.rotation.eulerAngles.z, -90.0f, 0), 0.01f, RotateMode.Fast);
			lastRotation = transform.rotation.eulerAngles;
		}
	}


}
