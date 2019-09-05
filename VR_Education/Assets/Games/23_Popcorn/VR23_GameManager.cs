using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VR23_GameManager : MonoBehaviour {

	public Transform player;
	public Transform spawnPosition;
	public GameObject popcornPrefab;

	private List<GameObject> popcorns = new List<GameObject>();

	void FixedUpdate () {

		if (VRInput.Trigger()) {
			if (popcorns.Count > 500) popcorns.RemoveAt(0);
			GameObject a = Instantiate(popcornPrefab, spawnPosition.position, Quaternion.identity);
			a.GetComponent<Rigidbody>().AddForce((player.position - spawnPosition.position) * 2.8f, ForceMode.Impulse);
			popcorns.Add(a);
		}

	}
}
