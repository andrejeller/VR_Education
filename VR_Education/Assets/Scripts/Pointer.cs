using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer:MonoBehaviour {

	public float _distance = 10.0f;
	public LineRenderer _lineRenderer = null;
	public LayerMask _everythingMask = 0;
	public LayerMask _interactableMask = 0;

	private Transform _currentOrigin = null;

	private void Awake() {
		PlayerEvents.OnControulerSource += UpdateOringin;
		PlayerEvents.OnTouchPadDown += ProcessTouchpadDown;
	}

	private void Start() {
		SetLineColor();
	}

	private void OnDestroy() {
		PlayerEvents.OnControulerSource -= UpdateOringin;
		PlayerEvents.OnTouchPadDown -= ProcessTouchpadDown;
	}

	private void Update() {
		Vector3 hitPoint = UpdateLine();

	}

	private Vector3 UpdateLine() {
		//Create ray
		RaycastHit hit = CreatedRaycats(_everythingMask);

		//Default end
		Vector3 endPosition = _currentOrigin.position + (_currentOrigin.forward * _distance);

		//Check hit
		if (hit.collider != null)
			endPosition = hit.point;

		//Set position
		_lineRenderer.SetPosition(0, _currentOrigin.position);
		_lineRenderer.SetPosition(1, endPosition);


		return endPosition;
	}

	private void UpdateOringin(OVRInput.Controller controller, GameObject controllerObject) {
		//Set origin of pointer
		_currentOrigin = controllerObject.transform;

		//is the laser visible?
		if (controller == OVRInput.Controller.Touchpad) _lineRenderer.enabled = false;
		else _lineRenderer.enabled = true;

	}

	private RaycastHit CreatedRaycats(int layer) {
		RaycastHit hit;

		Ray ray = new Ray(_currentOrigin.position, _currentOrigin.forward);
		Physics.Raycast(ray, out hit, _distance, layer);

		return hit;
	}

	private void SetLineColor() {
		if (!_lineRenderer) return;

		Color endColor = Color.white;
		endColor.a = 0.0f;

		_lineRenderer.endColor = endColor;

	}

	private void ProcessTouchpadDown() {

	}





}
