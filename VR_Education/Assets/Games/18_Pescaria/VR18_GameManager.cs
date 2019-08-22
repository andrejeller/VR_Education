﻿using System.Collections;
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

	public bool inWater = false, theresAFish = false;
	public GameObject ponta;
	public Vector3 pontaPos { get { return ponta.transform.position; } }

	public GameObject fishPrefab;
	public PathCreation.PathCreator fishPath;
	public List<GameObject> peixesNaAgua, peixesNoBarco;


	private IEnumerator Start() {
		for (int i = 0; i < 17; i++) {
			GenerateFish();
			yield return new WaitForSeconds(1.2f);
		}
		yield return null;
	}


	private void GenerateFish() {
		Vector3 pos = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-0.5f, -3.0f), Random.Range(-5.0f, 5.0f));
		GameObject fish = Instantiate(fishPrefab, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
		fish.transform.parent = fishPath.gameObject.transform;
		fish.GetComponent<VR18_TheFish>().SetPathCreator(fishPath);
		//peixesNaAgua.Add(fish);
	}

	private void FishToBoat(GameObject fish) {

		peixesNaAgua.Remove(fish);
	}

}
