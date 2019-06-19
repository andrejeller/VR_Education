using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR06_VirusSpwan:MonoBehaviour {


	public GameObject spawnPoint;
	public GameObject virusPrefab;

	private void Start() {

		InvokeRepeating("SpawnNew", 0.7f, 0.7f);

	}



	private void SpawnNew() {

		Vector3 pos = new Vector3(spawnPoint.transform.position.x, Random.Range(-1.5f, 1.5f), spawnPoint.transform.position.z + Random.Range(-0.5f, 0.5f));
		GameObject a = Instantiate(virusPrefab, pos, Quaternion.identity);

		a.transform.DOMoveX(0, 1.2f, false)
			.OnComplete(() => { a.transform.DOMoveZ(-15.0f, 4.3f, false).OnComplete(() => { a.transform.DOMoveX(8.0f, 3.5f, false).OnComplete(() => { Destroy(gameObject); }); }); });
	}
}
