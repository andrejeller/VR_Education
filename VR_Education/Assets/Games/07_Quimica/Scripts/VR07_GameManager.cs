using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR07_GameManager : MonoBehaviour {

	public static VR07_GameManager instance;
	private void Awake() {
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}


	public Pointer pointer;

}
