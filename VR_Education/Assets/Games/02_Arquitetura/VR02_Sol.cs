using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR02_Sol : MonoBehaviour, IInteractable {

	public GameObject DirectionalLight;
	private Vector3 lastRotation;

	private bool isHolding = false;

	public Camera cam;

	private void Start() {
		lastRotation = transform.rotation.eulerAngles;
		isHolding = false;
	}

	void Update() {
		if (!isHolding) return;

		//OVRInput.Controller.

		if (Input.GetMouseButton(0)) {

			Debug.LogError("MouseButton ");

			transform.LookAt(cam.ViewportToWorldPoint(Input.mousePosition));
		}


		if (lastRotation != transform.rotation.eulerAngles) {
			DirectionalLight.transform.DORotate(new Vector3(transform.rotation.eulerAngles.z, -90.0f, 0), 0.01f, RotateMode.Fast);
			lastRotation = transform.rotation.eulerAngles;
		}
	}

	
	private void OnMouseEnter() {
		isHolding = true;
		Debug.LogError("MouseOn");
	}

	private void OnMouseExit() {
		isHolding = false;
		Debug.LogError("MouseOff");
	}

	public IEnumerable OnPointerExit() {
		throw new System.NotImplementedException();
	}

	public IEnumerable OnPointerOver() {
		throw new System.NotImplementedException();
	}

	public IEnumerable OnPress() {
		isHolding = true;
		throw new System.NotImplementedException();
	}

	public IEnumerable OnRelease() {
		isHolding = false;
		throw new System.NotImplementedException();
	}



}
