using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VR23_GameManager : MonoBehaviour {

	public TextMeshProUGUI text;

	public Transform player;
	public Transform spawnPosition;
	public GameObject popcornPrefab;

	private List<GameObject> popcorns = new List<GameObject>();
	private int poolIndex = 0;
	private int popMax = 400;

	void FixedUpdate () {

		if (VRInput.Trigger()) {

			if (popcorns.Count < popMax) {
				GameObject a = Instantiate(popcornPrefab, spawnPosition.position, Quaternion.identity);
				a.GetComponent<Rigidbody>().AddForce((player.position - spawnPosition.position) * 2.9f, ForceMode.Impulse);
				popcorns.Add(a);
				text.text = "A: " + popcorns.Count;
			}
			else {
				if (poolIndex >= popMax) poolIndex = 0;

				popcorns[poolIndex].transform.position = spawnPosition.position;
				popcorns[poolIndex].GetComponent<VR23_PopCorn>().UNPop();
				popcorns[poolIndex].GetComponent<Rigidbody>().AddForce((player.position - spawnPosition.position) * 2.9f, ForceMode.Impulse);
				text.text = "UNPop: " + poolIndex;
				poolIndex++;
			}
		}

	}
}
