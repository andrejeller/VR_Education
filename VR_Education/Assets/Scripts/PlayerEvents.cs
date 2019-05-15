using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents:MonoBehaviour {

	#region Events
	public static UnityAction OnTouchPadUp = null;
	public static UnityAction OnTouchPadDown = null;

	public static UnityAction OnTriggerPressed = null;
	public static UnityAction OnTriggerRelesase = null;

	public static UnityAction<OVRInput.Controller, GameObject> OnControulerSource = null;
	#endregion


	#region Anchors
	public GameObject _LeftAnchor;
	public GameObject _RightAnchor;
	public GameObject _HeadAnchor;
	
	#endregion
	
	#region Input
	private Dictionary<OVRInput.Controller, GameObject> _ControllerSets = null;
	private OVRInput.Controller _InputSource = OVRInput.Controller.None;
	private OVRInput.Controller _Controler = OVRInput.Controller.None;
	private bool _InputActive = true;
	#endregion


	private void Awake() {
		OVRManager.HMDMounted += PlayerFound;
		OVRManager.HMDUnmounted += PlayerLost;

		_ControllerSets = CreateControllSets();
	}

	private void OnDestroy() {
		OVRManager.HMDMounted -= PlayerFound;
		OVRManager.HMDUnmounted -= PlayerLost;
	}

	void Update() {
		if (!_InputActive) return;

		//Check if controller exists
		CheckForControler();
		//Check for input source
		CheckInputSource();
		//Check for actual input
		Input();

	}

	private void CheckForControler() {
		OVRInput.Controller controllerCheck = _Controler;
		//Right remote
		if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
			controllerCheck = OVRInput.Controller.RTrackedRemote;
		
		//Left remote
		if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
			controllerCheck = OVRInput.Controller.LTrackedRemote;

		//if no remote, headset
		if (!OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote) && 
			!OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))

			controllerCheck = OVRInput.Controller.Touchpad; //na vdd vai virar "pausar game, pois o oculus go nao tem touchpad"

		//Update
		_Controler = UpdateSource(controllerCheck, _Controler);
	}
	private void CheckInputSource() {
		//Update
		_InputSource = UpdateSource(OVRInput.GetActiveController(), _InputSource);
	}
	private void Input() {
		if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) {
			if (OnTriggerPressed != null)
				OnTriggerPressed();
		}
		if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)) {
			if (OnTriggerRelesase != null)
				OnTriggerRelesase();
		}

		//Touchpad down
		if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad)) {
			if (OnTouchPadDown != null)
				OnTouchPadDown();
		}

		//Touchpad up
		if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad)) {
			if (OnTouchPadUp != null)
				OnTouchPadUp();
		}
	}

	private OVRInput.Controller UpdateSource(OVRInput.Controller check, OVRInput.Controller previous) {

		//if value are the same, return
		if (check == previous) return previous;
		//get controler object
		GameObject controllerObject = null;
		_ControllerSets.TryGetValue(check, out controllerObject);

		//if no controller, set to the head
		if (controllerObject == null)
			controllerObject = _HeadAnchor;

		//send out event
		if (OnControulerSource != null)
			OnControulerSource(check, controllerObject);

		//return new value
		return check;
	}

	private void PlayerFound() {
		_InputActive = true;
	}
	private void PlayerLost() {
		_InputActive = false;
	}

	private Dictionary<OVRInput.Controller, GameObject> CreateControllSets() {
		Dictionary<OVRInput.Controller, GameObject> newSets = new Dictionary<OVRInput.Controller, GameObject>() {
			{ OVRInput.Controller.LTrackedRemote, _LeftAnchor },
			{ OVRInput.Controller.RTrackedRemote, _RightAnchor },
			{ OVRInput.Controller.Touchpad, _HeadAnchor }

			// + none
		};


		return newSets;
	}
}
