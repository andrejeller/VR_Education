using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VR02_Bdg : MonoBehaviour {

	public Text debugText;
	public GameObject ancora;


	public void Update() {
		debugText.text = "x-> " + transform.rotation.x + System.Environment.NewLine +
						 "y-> " + transform.rotation.y + System.Environment.NewLine +
						 "z-> " + transform.rotation.z + System.Environment.NewLine;
	}
}
