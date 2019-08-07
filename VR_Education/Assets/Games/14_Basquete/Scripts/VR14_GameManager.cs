using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR14_GameManager:MonoBehaviour {
	public static VR14_GameManager instance;
	private void Awake() {
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}

	public GameObject hand, anchor;
	public GameObject ballPrefab;
	private GameObject actualBall;
	public bool HandOnShelf = false;
	private bool GeneratingBall = false;

	void Update() {

		if (/*HandOnShelf &&*/ !GeneratingBall && (VRInput.TriggerDown() || VRInput.aBotaoTesteDown())) {
			hand.SetActive(false);
			GenerateBall();
		}
		else if (GeneratingBall && (VRInput.TriggerUp() || VRInput.aBotaoTesteDown())) {
			hand.SetActive(true);
			ThrowBall();
		}
	}


	private void GenerateBall() {
		GeneratingBall = true;
		actualBall = Instantiate(ballPrefab, anchor.transform);
		actualBall.transform.localPosition = new Vector3(0, 0, 1.0f);
	}

	private void ThrowBall() {
		actualBall.GetComponent<Rigidbody>().AddForce(anchor.transform.forward * 90, ForceMode.Acceleration);
		actualBall.GetComponent<Rigidbody>().useGravity = true;
		actualBall.transform.parent = null;
		actualBall = null;
	}



}
