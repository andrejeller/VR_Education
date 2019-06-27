using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR08_GameManager : MonoBehaviour {

	public static VR08_GameManager instance;
	private void Awake() {
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}


	public Pointer pointer;
}
