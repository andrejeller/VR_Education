using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR09_NextButton : MonoBehaviour, IInteractable {


	public IEnumerable OnTriggerPress() {
		VR09_GameManager.instance.GetNewWord();
		yield return null;
	}


	private void OnMouseDown() {
		VR09_GameManager.instance.GetNewWord();
	}

	public IEnumerable OnPointerExit() {
		transform.DOScale(1.0f, 0.3f);
		yield return null;
	}
	public IEnumerable OnPointerOver() {
		transform.DOScale(1.2f, 0.3f);
		yield return null;
	}
	public IEnumerable OnTriggerHold() {
		throw new System.NotImplementedException();
	}
	public IEnumerable OnTriggerRelease() {
		throw new System.NotImplementedException();
	}

}
