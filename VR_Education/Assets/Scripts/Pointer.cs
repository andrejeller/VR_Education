using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pointer:MonoBehaviour {

	public LineRenderer _lineRenderer = null;
	public LayerMask _everythingMask = 0;
	public LayerMask _interactableMask = 0;
	public UnityAction<Vector3, GameObject> OnPointUpdate = null;

	private Transform _currentOrigin = null;
	private GameObject _currentObject = null;
	private GameObject _lastObject = null;
	private float _distance = 40.0f;

	private void Awake() {
		PlayerEvents.OnControulerSource += UpdateOringin;
		PlayerEvents.OnTriggerPressed += OnTriggerPress;
		PlayerEvents.OnTriggerPressed += OnriggerRelesase;
		//PlayerEvents.OnTouchPadDown += ProcessTouchpadDown;
	}

	private void Start() {
		SetLineColor();
	}

	private void OnDestroy() {
		PlayerEvents.OnControulerSource -= UpdateOringin;
		PlayerEvents.OnTriggerPressed -= OnTriggerPress;
		//PlayerEvents.OnTouchPadDown -= ProcessTouchpadDown;
	}

	private void Update() {
		Vector3 hitPoint = UpdateLine();

		_currentObject = UpdatePointerStatus();

		if (_currentObject != null) {

			_lastObject = _currentObject;
			_currentObject.Send<IInteractable>(_ => _.OnPointerOver());
		}
		else {

			_lastObject.Send<IInteractable>(_ => _.OnPointerExit());
			_lastObject = null;
		}

		if (OnPointUpdate != null)
			OnPointUpdate(hitPoint, _currentObject);
	}


	#region LineThings
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
		//return Vector3.zero;
	}

	private void UpdateOringin(OVRInput.Controller controller, GameObject controllerObject) {
		//Set origin of pointer
		_currentOrigin = controllerObject.transform;

		//is the laser visible?
		if (controller == OVRInput.Controller.Touchpad) _lineRenderer.enabled = false;
		else _lineRenderer.enabled = true;

	}

	private GameObject UpdatePointerStatus() {
		//create ray
		RaycastHit hit = CreatedRaycats(_interactableMask);

		//check hit
		if (hit.collider)
			return hit.collider.gameObject;

		//return
		return null;
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
	#endregion

	private void OnTriggerPress() {
		if (!_currentObject) return;
		_currentObject.Send<IInteractable>(_ => _.OnPress());
	}

	private void OnriggerRelesase() {
		if (!_currentObject) return;
		_currentObject.Send<IInteractable>(_ => _.OnRelease());
	}

}
