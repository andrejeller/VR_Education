using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR00_Button : MonoBehaviour, IInteractable {

	public int buttonID;

	public IEnumerable OnPointerOver() {
		transform.DOScale(1.1f, 0.2f);
		yield return null;
	}

	public IEnumerable OnPointerExit() {
		transform.DOScale(1.0f, 0.2f);
		yield return null;
	}

	public IEnumerable OnPress() {
		transform.DORotate(Vector3.zero, 0.7f, RotateMode.FastBeyond360);
		yield return new WaitForSeconds(0.7f);
		ClickMe();
	}

	public void ClickMe() {
		SceneLoader.instance.Load(buttonID);
	}

	public IEnumerable OnRelease() {
		throw new System.NotImplementedException();
	}

	public IEnumerable OnHold() {
		throw new System.NotImplementedException();
	}
}
