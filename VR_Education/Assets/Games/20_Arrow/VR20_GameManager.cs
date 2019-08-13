using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR20_GameManager : MonoBehaviour {

	public Transform bow;
	public GameObject anchor;
	public GameObject arrowPrefab;

	private Vector3 wind;
	private bool GeneratingArrow = false;
	private GameObject actualArrow;
	private float throwForce = 90;

	void Update () {
		if (!GeneratingArrow && (VRInput.TriggerDown() || VRInput.aBotaoTesteDown())) {
			//hand.SetActive(false);
			//animação de puxar e soltar
			GenerateArrow();
		}
		else if (GeneratingArrow && (VRInput.TriggerUp() || VRInput.aBotaoTesteDown())) {
			//hand.SetActive(true);
			//animação de puxar e soltar
			ThrowArrow();
		}
	}


	private void GenerateArrow() {
		GeneratingArrow = true;
		actualArrow = Instantiate(arrowPrefab, anchor.transform);
		actualArrow.transform.localPosition = new Vector3(0, 0, 10.0f);
	}
	private void ThrowArrow() {
		actualArrow.GetComponent<Rigidbody>().AddForce(anchor.transform.forward * throwForce, ForceMode.Impulse);
		actualArrow.GetComponent<Rigidbody>().useGravity = true;
		actualArrow.transform.parent = null;
		actualArrow = null;
		GeneratingArrow = false;
	}

}
