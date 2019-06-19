using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR06_GameManager:MonoBehaviour {

	public static VR06_GameManager instance;
	private void Awake() {
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}

	[Header("Prefabs")]
	public VR06_Seringa seringa;
	public GameObject tiro;
	public GameObject slime;


	[Header("Audios")]
	public AudioClip explosion;
	public AudioClip shoot;

	public AudioSource sound;


	private void Update() {

		if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.Q)) {
			Shoot();
			seringa.Press();
		}

		if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyUp(KeyCode.Q))
			seringa.Release();
	}


	private void Shoot() {
		GameObject newA = Instantiate(tiro, seringa.ponta.transform.position, seringa.ponta.rotation);
		newA.GetComponent<VR06_Tiro>().shoteME();
		sound.PlayOneShot(shoot, 1.0f);
		newA.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
		newA.transform.DOScale(1.0f, 0.5f);
	}


	public void VirusDie(Transform pos) {
		sound.PlayOneShot(explosion, 1.0f);
		GameObject a = Instantiate(slime, pos.position, Quaternion.identity);
		Destroy(a, 0.5f);
	}

}
