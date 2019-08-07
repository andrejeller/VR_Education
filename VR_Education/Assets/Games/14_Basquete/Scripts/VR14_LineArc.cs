using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class VR14_LineArc:MonoBehaviour {

	LineRenderer lr;


	private float radianAngles;
	private float angle, InitialY, g, vel = 100;
	private int pointsCount = 10;


	private void Awake() {
		lr = GetComponent<LineRenderer>();
		g = Mathf.Abs(Physics.gravity.y);
	}

	private void Start() {
		InitialY = VR14_GameManager.instance.anchor.transform.position.y;
	}

	private void Update() {
		angle = VR14_GameManager.instance.anchor.transform.rotation.eulerAngles.x;
		if (angle > 0) RenderArc();
	}

	private void RenderArc() {
		lr.positionCount = pointsCount + 1;
		lr.SetPositions(CalculateArcArray());
	}


	private Vector3[] CalculateArcArray() {
		Vector3[] arcArray = new Vector3[pointsCount + 1];

		radianAngles = Mathf.Deg2Rad * angle;
		float maxDistance = (vel * vel * Mathf.Sin(2 * radianAngles)) / g;

		for (int i = 0; i <= pointsCount; i++) {
			float t = (float)i / (float)pointsCount;
			arcArray[i] = CalculateArcPoint(t, maxDistance);
		}


		return arcArray;
	}

	private Vector3 CalculateArcPoint(float t, float maxDistance) {
		float x = t * maxDistance;
		float y = InitialY + x * Mathf.Tan(radianAngles) - ((g * x * x) / (2 * vel * vel * Mathf.Cos(radianAngles) * Mathf.Cos(radianAngles)));

		return new Vector3(0, y, x);
	}


}
