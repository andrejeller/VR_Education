using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR09_NextButton : MonoBehaviour, IInteractable {


	public IEnumerable OnTriggerPress() {
		VR09_GameManager.instance.GetNewWord();
		yield return null;
	}


	private void OnMouseDown() {
		VR09_GameManager.instance.GetNewWord();
	}

	public IEnumerable OnPointerExit() {
		throw new System.NotImplementedException();
	}
	public IEnumerable OnPointerOver() {
		throw new System.NotImplementedException();
	}
	public IEnumerable OnTriggerHold() {
		throw new System.NotImplementedException();
	}
	public IEnumerable OnTriggerRelease() {
		throw new System.NotImplementedException();
	}

}
