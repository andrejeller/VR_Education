using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VR24_Balloon : MonoBehaviour {

	public TextMeshProUGUI number;
	public Renderer myMaterial;
	private string myNumber;

	private void Init(string withNumber, Color withColor) {
		myNumber = withNumber;
		number.text = withNumber.ToString();
		myMaterial.material.color = withColor;
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "") {
			Destroy(collision.gameObject);
			//explodir
		}
	}

}
