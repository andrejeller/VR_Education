using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR06_GameManager:MonoBehaviour {

	public VR06_Seringa seringa;
	public GameObject tiro;


	private void Update() {

		if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.Q)) {
			Shoot();
			seringa.Press();
		}

		if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyUp(KeyCode.Q))
			seringa.Release();
	}


	private void Shoot() {
		GameObject newA = Instantiate(tiro, seringa.ponta.transform.position, seringa.ponta.rotation);
		newA.GetComponent<VR06_Tiro>().shoteME();
		newA.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
		newA.transform.DOScale(1.0f, 0.5f);
	}

}
