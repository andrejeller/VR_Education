using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR02_FlipButton : MonoBehaviour {

	public void FlipTo(bool Left) {
		if (Left) VR02_GameManager.instance.RotateActiveBuilding('l');
		else      VR02_GameManager.instance.RotateActiveBuilding('r');
	}

}
