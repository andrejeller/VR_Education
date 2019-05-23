using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR02_GameManager:MonoBehaviour {

	public static VR02_GameManager instance;

	public GameObject[] buildings = new GameObject[4];
	public int[] buildingsRotations = { 0, 0, 0, 0 };
	private Vector3[] rotations = { new Vector3(0, 45, 0), new Vector3(0, 135, 0), new Vector3(0, 255, 0), new Vector3(0, 315, 0) };
	private int builingsCount = 4;
	private int ActiveBuilding = 0;

	public VR02_ToggleGroup tg;

	private void Awake() {
		if (instance == null) instance = this;
		else Destroy(gameObject);
	}


	private void Start() {
		tg.InitializeToggls();
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


		if (Input.GetKeyDown(KeyCode.A)) {
			tg.ActiveOnlyToggle(0);
			Debug.LogWarning("try to change");
		}


		if (Input.GetKeyDown(KeyCode.LeftArrow))
			RotateActiveBuilding('l');
		if (Input.GetKeyDown(KeyCode.RightArrow))
			RotateActiveBuilding('r');
	}

	public void RotateActiveBuilding(char side) {

		if (side == 'r') {
			buildingsRotations[ActiveBuilding]++;
			if (buildingsRotations[ActiveBuilding] > 3) buildingsRotations[ActiveBuilding] = 0;

			//buildings[ActiveBuilding].transform.Rotate(new Vector3(0, 90, 0));
			buildings[ActiveBuilding].transform.DORotate(rotations[buildingsRotations[ActiveBuilding]], 0.7f, RotateMode.Fast);
		}
		if (side == 'l') {
			buildingsRotations[ActiveBuilding]--;
			if (buildingsRotations[ActiveBuilding] < 0) buildingsRotations[ActiveBuilding] = 3;

			//buildings[ActiveBuilding].transform.Rotate(new Vector3(0, -90, 0));
			buildings[ActiveBuilding].transform.DORotate(rotations[buildingsRotations[ActiveBuilding]], 0.7f, RotateMode.Fast);
		}
	}


	public void ActiveOnlyBuilding(int number) {
		ActiveBuilding = number;
		tg.ActiveOnlyToggle(number);

		for (int i = 0; i < builingsCount; i++) {
			bool visibility = false;
			if (i == number) visibility = true;
			buildings[i].SetActive(visibility);
		}
	}
}
