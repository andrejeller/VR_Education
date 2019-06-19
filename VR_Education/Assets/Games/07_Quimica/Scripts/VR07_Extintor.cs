using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR07_Extintor : MonoBehaviour, IInteractable {


	public GameObject particle;
	public Transform wereToInstanciate;


	public IEnumerable OnTriggerPress() {
		GameObject a = Instantiate(particle, wereToInstanciate);
		Destroy(a, 1.3f);
		yield return null;
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
