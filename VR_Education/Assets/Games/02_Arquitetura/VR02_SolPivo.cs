using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR02_SolPivo:MonoBehaviour {

	public GameObject DirectionalLight;
	private Vector3 lastRotation;

	private bool isHolding = false;
	//private float[] positions = { 180, ‭112, 90, 45, 0};

	public Camera cam;
	public Pointer pointer;
	public GameObject sol;

	private void Start() {
		lastRotation = transform.rotation.eulerAngles;
		isHolding = false;
	}

	private void Update() {
		UpdateSol();
	}

	public void UpdateSol() {

		//float distance = Vector3.Distance(sol.transform.position, pointer.GetOriginPosition().position);
		//Vector3 pos = pointer.GetOriginPosition().position + (pointer.GetOriginPosition().forward * distance);


		Vector2 a = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

		//transform.LookAt(new Vector3(pos.x, pos.y, -20.0f));
		//transform.LookAt(new Vector3(pos.x, pos.y, -20.0f));

		//transform.Rotate(new Vector3(TranslateTo180(a.x), 0, 0));
		if (a.x != 0)
			transform.DORotate(new Vector3(TranslateTo180(a.x), 45, 0), 0.01f, RotateMode.Fast);
		else {

		}

		// && ((-transform.rotation.eulerAngles.x) < 180.0f && (-transform.rotation.eulerAngles.x) > 0.0f)
		if (lastRotation != transform.rotation.eulerAngles) {
			DirectionalLight.transform.DORotate(new Vector3(-transform.rotation.eulerAngles.x, -90.0f, 0), 0.01f, RotateMode.Fast);
			lastRotation = transform.rotation.eulerAngles;
		}
	}

	private float TranslateTo180(float x) {

		if (x > -1.0f && x < -0.5f)
			return 180;

		else if (x > -0.5f && x < 0.0f)
			return 112;

		else if (x > 0.0f && x < 0.5f)
			return 45;

		else if (x > 0.5f && x < 1.0f)
			return 0;

		return 0;
	}

}
