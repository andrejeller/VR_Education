using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR02_GameManager:MonoBehaviour {

	public GameObject[] buildings = new GameObject[4];
	private int builingsCount = 4;


	private void Start() {
		ActiveOnlyBuilding(0);
	}


	private void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha1))
			ActiveOnlyBuilding(0);

		if (Input.GetKeyDown(KeyCode.Alpha2))
			ActiveOnlyBuilding(1);

		if (Input.GetKeyDown(KeyCode.Alpha3))
			ActiveOnlyBuilding(2);

		if (Input.GetKeyDown(KeyCode.Alpha4))
			ActiveOnlyBuilding(3);
	}

	public void ActiveOnlyBuilding(int number) {
		for (int i = 0; i < builingsCount; i++) {
			bool visibility = false;
			if (i == number) visibility = true;
			buildings[i].SetActive(visibility);
		}
	}
}
