using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR02_Sol:MonoBehaviour, IInteractable {

	public VR02_SolPivo pivo;

	public bool holding = false;
	public Pointer pointer;

	private void Start() {
		holding = false;
	}

	void Update() {
		if (!holding) return;

		Transform pOrigin = pointer.GetOriginPosition();
	
		float distance = Vector3.Distance(transform.position, pOrigin.position);
		Vector3 dist = pOrigin.position + (pOrigin.forward * distance);
		pivo.Update1(dist);
	}

	public IEnumerable OnTriggerHold() {
		holding = true;
		DEBUG.dbg.Updt("HOOLLLD");
		yield return null;
	}

	public IEnumerable OnTriggerRelease() {
		holding = false;
		DEBUG.dbg.Updt("release");
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
