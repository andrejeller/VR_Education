using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR07_Notebook:MonoBehaviour, IInteractable {

	public bool holding = false;
	private bool isOn = false;

	public GameObject image;

	private void Start() {
		image.SetActive(false);
	}

	private void toogl() {
		image.SetActive(isOn);
	}


	public IEnumerable OnTriggerPress() {
		isOn = !isOn;
		toogl();
		yield return null;
	}


	public IEnumerable OnTriggerHold() {
		//isOn = !isOn;
		yield return null;
	}

	public IEnumerable OnTriggerRelease() {
		throw new System.NotImplementedException();
	}

	public IEnumerable OnPointerExit() {
		throw new System.NotImplementedException();
	}
	public IEnumerable OnPointerOver() {
		throw new System.NotImplementedException();
	}
	
}
