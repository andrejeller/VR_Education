using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {

	private void Awake() {
		PlayerEvents.OnControulerSource += UpdateOringin;
		PlayerEvents.OnTouchPadDown += ProcessTouchpadDown;
	}

	private void OnDestroy() {
		PlayerEvents.OnControulerSource -= UpdateOringin;
		PlayerEvents.OnTouchPadDown -= ProcessTouchpadDown;
	}

	private void UpdateOringin(OVRInput.Controller controller, GameObject controllerObjects) {

	}

	private void ProcessTouchpadDown() {

	}
}
