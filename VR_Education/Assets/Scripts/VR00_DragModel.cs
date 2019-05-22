using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR00_DragModel : MonoBehaviour, IInteractable {


	public bool holding = false;
	public Pointer pointer;


	private void Update() {
		if (!holding) return;

		Transform pOrigin = pointer.GetOriginPosition();
		float distance = Vector3.Distance(transform.position, pOrigin.position);
		transform.position = pOrigin.position + (pOrigin.forward * distance);

	}

	public IEnumerable OnTriggerHold() {
		DEBUG.dbg.Updt("Hold");
		holding = true;
		yield return null;
	}

	public IEnumerable OnTriggerRelease() {
		holding = false;
		DEBUG.dbg.Updt("On Release");
		yield return null;
	}

	public IEnumerable OnPointerExit() {
		throw new System.NotImplementedException();
	}
	public IEnumerable OnPointerOver() {
		throw new System.NotImplementedException();
	}
	public IEnumerable OnTriggerPress() {
		throw new System.NotImplementedException();
	}
	
}
