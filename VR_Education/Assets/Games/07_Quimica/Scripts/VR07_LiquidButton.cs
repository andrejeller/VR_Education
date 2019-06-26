using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR07_LiquidButton : MonoBehaviour, IInteractable {

	public bool holding = false;
	public VR07_GenerateFakeFluid generator;


	public IEnumerable OnTriggerHold() {
		holding = true;
		transform.DOLocalMoveZ(0.02f, 0.15f, false);
		yield return null;
	}


	public IEnumerable OnTriggerRelease() {
		holding = false;
		transform.DOLocalMoveZ(0.00f, 0.15f, false);
		yield return null;
	}

	private void Update() {
		if (!holding) return;

		generator.Create();

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
