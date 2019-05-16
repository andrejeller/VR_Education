using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR02_Sol:MonoBehaviour, IInteractable {

	public VR02_SolPivo pivo;

	private bool isHolding = false;

	public GameObject qq;



	private void Start() {
		isHolding = false;
	}

	void Update() {
		//if (!isHolding) return;

		//pivo.UpdateSol();
	}


	public IEnumerable OnPointerExit() {
		qq.SetActive(true);
		yield return null;
	}

	public IEnumerable OnPointerOver() {
		qq.SetActive(false);
		yield return null;
	}

	public IEnumerable OnPress() {
		qq.SetActive(false);
		yield return null;

	}

	public IEnumerable OnRelease() {
		qq.SetActive(true);
		yield return null;
	}

	public IEnumerable OnHold() {
		isHolding = true;
		qq.SetActive(false);
		yield return null;
	}
}
