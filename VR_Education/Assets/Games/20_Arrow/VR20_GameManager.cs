using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR20_GameManager : MonoBehaviour {

	public Animation bow;
	public GameObject anchor;
	public GameObject arrowPrefab;

	private Vector3 wind;
	private bool GeneratingArrow = false;
	private GameObject actualArrow;
	private float throwForce = 160;

	void Update () {
		if (!GeneratingArrow && (VRInput.TriggerDown() || VRInput.aBotaoTesteDown())) {
			//animação de puxar e soltar
			GenerateArrow();
		}
		else if (GeneratingArrow && (VRInput.TriggerUp() || VRInput.aBotaoTesteUp())) {
			//animação de puxar e soltar
			ThrowArrow();
		}
	}


	private void GenerateArrow() {
		GeneratingArrow = true;
		bow["Copper_Bow_Armature|Draw"].speed = 3.0f;
		bow.Play("Copper_Bow_Armature|Draw");
		actualArrow = Instantiate(arrowPrefab, anchor.transform);
		actualArrow.transform.localPosition = new Vector3(0.0f, 0, 1.3f);
		actualArrow.transform.localRotation = Quaternion.Euler(0.0f, 90, 90);
		actualArrow.transform.DOLocalMove(new Vector3(0.0f, 0, -2.15f), 0.3f, false); //-1.43
	}
	private void ThrowArrow() {
		bow.Play("Copper_Bow_Armature|Fire");
		actualArrow.GetComponent<Rigidbody>().AddForce(anchor.transform.forward * throwForce, ForceMode.Impulse);
		actualArrow.GetComponent<Rigidbody>().useGravity = true;
		actualArrow.transform.DOScale(4.0f, 1.5f);
		actualArrow.transform.parent = null;
		actualArrow = null;
		GeneratingArrow = false;
	}

}
