using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vr02_solpos:MonoBehaviour {

	public Text debugText;


	public void Update() {
		debugText.text = "X-> " + transform.rotation.x + System.Environment.NewLine +
						 "Y-> " + transform.rotation.y + System.Environment.NewLine +
						 "Z-> " + transform.rotation.z + System.Environment.NewLine;
	}

}
