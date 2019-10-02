using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR28_DecreaseLight : MonoBehaviour {
    public float decrease;
    private Light lgt;
	// Use this for initialization
	void Start () {
        lgt = transform.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        lgt.intensity -= decrease;

    }
}
