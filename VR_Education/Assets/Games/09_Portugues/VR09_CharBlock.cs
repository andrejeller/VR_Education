using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[SelectionBase]
public class VR09_CharBlock : MonoBehaviour, IInteractable {

	public char myChar;
	public bool holding = false;

	public TextMeshProUGUI myText;

	public string texto { get { return myText.text;  } set { myText.text = value; myChar = value[0]; } }



	private void Update() {
		if (!holding) return;

		Transform pOrigin = VR09_GameManager.instance.pointer.GetOriginPosition();
		float distance = Vector3.Distance(transform.position, pOrigin.position);
		Vector3 longDistance = pOrigin.position + (pOrigin.forward * distance);
		transform.localPosition = new Vector3(longDistance.x + 175.2f, transform.localPosition.y, longDistance.y - 95.7f);

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
