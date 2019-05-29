using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR05_GameManager:MonoBehaviour {

	public static VR05_GameManager instance;

	private void Awake() {
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}



	public VR05_Planeta[] planetas;
	public Pointer pointer;

	private void Start() {
		pointer.Distance = 100000.0f;
	}

}
