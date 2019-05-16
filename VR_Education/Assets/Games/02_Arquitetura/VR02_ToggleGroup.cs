using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VR02_ToggleGroup : MonoBehaviour {


	public GameObject[] toggls = new GameObject[4];


	public void InitializeToggls() {
		toggls[0].SetActive(true);
		toggls[1].SetActive(false);
		toggls[2].SetActive(false);
		toggls[3].SetActive(false);
	}

	public void ActiveOnlyToggle(int index) {

		for (int i = 0; i < 4; i++) {
			if (i == index) {
				toggls[i].SetActive(true);
				continue;
			}
			toggls[i].SetActive(false);
		}

	}

}
