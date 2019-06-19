using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class VR07_TuboEnsaio:MonoBehaviour, IInteractable {

	public bool holding = false;
	public Pointer pointer;

	private void Update() {
		if (!holding) return;

		Transform pOrigin = VR07_GameManager.instance.pointer.GetOriginPosition();
		float distance = Vector3.Distance(transform.position, pOrigin.position);
		Vector3 nextPosition = pOrigin.position + (pOrigin.forward * distance);
		transform.position = new Vector3(transform.position.x, nextPosition.y /*- (transform.position.y - nextPosition.y)*/, nextPosition.z);

		//Ver esse rotations aquii
		transform.localRotation = pOrigin.rotation;
	}

	public IEnumerable OnTriggerHold() {
		holding = true;
		yield return null;
	}

	public IEnumerable OnTriggerRelease() {
		holding = false;
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
