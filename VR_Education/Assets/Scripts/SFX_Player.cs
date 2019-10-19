using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum sfxs2 {
lk,
jk

}

public class SFX_Player : MonoBehaviour {

    public AudioSource[] AudioSource;

    public AudioClip[] SFX;
    public sfxs nome;

    // Use this for initialization
    void Start () {
        AudioSource[1].playClip();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
