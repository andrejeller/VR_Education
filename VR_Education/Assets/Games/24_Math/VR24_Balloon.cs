using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VR24_Balloon : MonoBehaviour {

	public TextMeshProUGUI number;
	public Renderer myMaterial;

	private void Start() {
		Init(3, Color.red);
	}

	private void Init(int withNumber, Color withColor) {
		number.text = withNumber.ToString();
		myMaterial.material.color = withColor;
	}

}
