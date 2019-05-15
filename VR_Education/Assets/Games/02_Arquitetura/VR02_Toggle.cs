using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VR02_Toggle:MonoBehaviour, IInteractable {

	public int myBuilding;
	public Toggle myToggle;
	public ToggleGroup a;

	public void ActiveMyBuilding() {

		//a.NotifyToggleOn(myToggle);
		myToggle.isOn = true;
		//myToggle.set = true;
		//VR02_GameManager.instance.ActiveOnlyBuilding(myBuilding);
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
}
