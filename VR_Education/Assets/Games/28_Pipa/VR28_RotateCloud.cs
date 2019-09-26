using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR28_RotateCloud : MonoBehaviour {
    public float spd = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0f, spd, 0f));
	}
}
