using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR02_Sol : MonoBehaviour {

	public GameObject DirectionalLight;
	private Vector3 lastRotation;

	private void Start() {
		lastRotation = transform.rotation.eulerAngles;
	}

	void Update() {
		if (lastRotation != transform.rotation.eulerAngles) {
			DirectionalLight.transform.DORotate(new Vector3(transform.rotation.eulerAngles.z, -90.0f, 0), 0.01f, RotateMode.Fast);
			lastRotation = transform.rotation.eulerAngles;
		}
	}
}
