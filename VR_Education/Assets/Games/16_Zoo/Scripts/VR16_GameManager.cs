using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR16_GameManager : MonoBehaviour {
	public static VR16_GameManager instance;
	private void Awake() {
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}

	public AudioSource sound;
	[Space]
	public Pointer pointer;


	private void Start() {
		pointer.Distance = 2700.0f;
	}






	public void Play(AudioClip clip) {
		sound.PlayOneShot(clip, 1.0f);
	}

}
