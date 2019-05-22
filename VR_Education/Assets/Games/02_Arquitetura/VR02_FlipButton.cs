using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR02_FlipButton : MonoBehaviour, IInteractable {

	public bool FlipToLeft;

	public void FlipTo() {
		if (FlipToLeft) VR02_GameManager.instance.RotateActiveBuilding('l');
		else      VR02_GameManager.instance.RotateActiveBuilding('r');
	}

	public IEnumerable OnTriggerHold() {
		throw new System.NotImplementedException();
	}

	public IEnumerable OnPointerExit() {
		throw new System.NotImplementedException();
	}

	public IEnumerable OnPointerOver() {
		throw new System.NotImplementedException();
	}

	public IEnumerable OnTriggerPress() {
		if (FlipToLeft) VR02_GameManager.instance.RotateActiveBuilding('l');
		else VR02_GameManager.instance.RotateActiveBuilding('r');
		yield return null;
	}

	public IEnumerable OnTriggerRelease() {
		throw new System.NotImplementedException();
	}
}
