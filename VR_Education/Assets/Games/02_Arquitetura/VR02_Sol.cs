using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR02_Sol : MonoBehaviour, IInteractable {

	public VR02_SolPivo pivo;
	
	private bool isHolding = false;


	private void Start() {
		isHolding = false;
	}

	void Update() {
		//if (!isHolding) return;

		//OVRInput.Controller.

		if (Input.GetMouseButton(0)) {

			//Debug.LogError("MouseButton ");
			//pivo.UpdateSol(Input.mousePosition);
		}


	}

	
	private void OnMouseEnter() {
		isHolding = true;
		//Debug.LogError("MouseOn");
	}

	private void OnMouseExit() {
		isHolding = false;
		//Debug.LogError("MouseOff");
	}

	public IEnumerable OnPointerExit() {
		throw new System.NotImplementedException();
	}

	public IEnumerable OnPointerOver() {
		throw new System.NotImplementedException();
	}

	public IEnumerable OnPress() {
		isHolding = true;
		throw new System.NotImplementedException();
	}

	public IEnumerable OnRelease() {
		isHolding = false;
		throw new System.NotImplementedException();
	}



}
