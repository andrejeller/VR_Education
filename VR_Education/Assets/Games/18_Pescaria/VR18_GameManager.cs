using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR18_GameManager:MonoBehaviour {

	public static VR18_GameManager instance;
	private void Awake() {
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}

	public bool inWater = false;





	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}
}
