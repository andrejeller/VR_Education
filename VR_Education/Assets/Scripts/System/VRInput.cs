using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInput {

	public static bool TriggerDown() {
		return OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger);
	}
	public static bool TriggerUp() {
		return OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger);
	}
	public static bool Trigger() {
		return OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
	}

	public static Vector2 Axes() {
		return OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
	}





	public static bool aBotaoTesteDown() {
		return Input.GetKeyDown(KeyCode.A);
	}

	public static bool aBotaoTesteUp() {
		return Input.GetKeyUp(KeyCode.A);
	}
}
