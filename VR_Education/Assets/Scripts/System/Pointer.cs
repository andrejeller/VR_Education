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
	private float _distance = 100.0f;
	private bool holdingObject = false;

	private void Awake() {
		PlayerEvents.OnControulerSource += UpdateOringin;
		PlayerEvents.OnTriggerPressed += OnTriggerPress;
		PlayerEvents.OnTriggerHold += OnTriggerHold;
		PlayerEvents.OnTriggerRelesase += OnTriggerRelesase;
		//PlayerEvents.OnTouchPadDown += ProcessTouchpadDown;
	}

	private void Start() {
		SetLineColor();
	}

	private void OnDestroy() {
		PlayerEvents.OnControulerSource -= UpdateOringin;
		//PlayerEvents.OnTriggerPressed -= OnTriggerPress;
		//PlayerEvents.OnTriggerRelesase -= OnTriggerRelesase;
		//PlayerEvents.OnTriggerHold -= OnTriggerHold;
		//PlayerEvents.OnTouchPadDown -= ProcessTouchpadDown;
	}

	private void Update() {
		Vector3 hitPoint = UpdateLine();

		if (!holdingObject)
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


	public Transform GetOriginPosition() {
		return _currentOrigin;
	}


	#region LineThings
	private Vector3 UpdateLine() {
		//Create ray
		RaycastHit hit = CreatedRaycats(_everythingMask);

		//Default end
		Vector3 endPosition = _currentOrigin.position + (_currentOrigin.forward * _distance);

		//Check hit and Check if is not holding an object
		if (hit.collider != null && !holdingObject)
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

	private GameObject UpdatePointerStatus() {
		//create ray
		RaycastHit hit = CreatedRaycats(_interactableMask);

		//check hit ad if is not holding an object
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
		//_currentObject.SetActive(false);
		_currentObject.Send<IInteractable>(_ => _.OnTriggerPress());
	}

	private void OnTriggerHold() {
		if (!_currentObject) return;
		holdingObject = true;
		_currentObject.Send<IInteractable>(_ => _.OnTriggerHold());
	}

	private void OnTriggerRelesase() {
		if (!_currentObject) return;
		holdingObject = false;
		_currentObject.Send<IInteractable>(_ => _.OnTriggerRelease());
	}

}
