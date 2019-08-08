using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR07_Table : MonoBehaviour, IInteractable {

	//Z -> -15.7 a 4.5

	public bool holding = false;
	public Pointer pointer;
	private Vector3 awayPosition;
	private float _pZpos;

	private void Start() {
		pointer = VR07_GameManager.instance.pointer;
	}

	private void Update() {
		if (!holding) return;

		Transform pOrigin = pointer.GetOriginPosition();
		float distance = Vector3.Distance(transform.position, pOrigin.position);
		//float posZ = Mathf.Lerp()
		//Vector3 nextPosition = new Vector3();

		awayPosition = pOrigin.position + (pOrigin.forward * distance);
		float inputPositionZ = awayPosition.z + 15.7f;
		if (inputPositionZ < 0) inputPositionZ = 0;
		if (inputPositionZ > 20.2f) inputPositionZ = 20.2f;

		_pZpos = Mathf.Lerp(-15.7f, 4.5f, inputPositionZ / 20.2f);
		transform.parent.localPosition = new Vector3(transform.parent.localPosition.x, transform.parent.localPosition.y, _pZpos);


		//transform.parent.transform.position = pOrigin.position + (pOrigin.forward * distance);

	}

	public IEnumerable OnTriggerHold() {
		holding = true;
		yield return null;
	}

	public IEnumerable OnTriggerRelease() {
		holding = false;
		yield return null;
	}

	public IEnumerable OnPointerOver() {
		throw new System.NotImplementedException();
	}

	public IEnumerable OnPointerExit() {
		throw new System.NotImplementedException();
	}

	public IEnumerable OnTriggerPress() {
		throw new System.NotImplementedException();
	}
}
