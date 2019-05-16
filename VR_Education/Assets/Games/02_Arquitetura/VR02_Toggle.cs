using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR02_Toggle:MonoBehaviour, IInteractable {

	public int myBuilding;

	public void ActiveMyBuilding() {
		
		VR02_GameManager.instance.ActiveOnlyBuilding(myBuilding);
	}

	public IEnumerable OnPress() {
		ActiveMyBuilding();
		yield return null;
	}


	public IEnumerable OnPointerExit() {
		throw new System.NotImplementedException();
	}

	public IEnumerable OnPointerOver() {
		throw new System.NotImplementedException();
	}

	public IEnumerable OnRelease() {
		throw new System.NotImplementedException();
	}

	public IEnumerable OnHold() {
		throw new System.NotImplementedException();
	}
}
