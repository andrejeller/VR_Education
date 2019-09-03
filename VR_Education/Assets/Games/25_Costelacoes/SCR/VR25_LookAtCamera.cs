using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR25_LookAtCamera : MonoBehaviour {
    public GameObject playerhead;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
//
        var b = Quaternion.identity;
        var a = playerhead.transform.localRotation;
        b.y = a.y;
        //transform.Rotate(new Vector3(0f, 0f,  playerhead.transform.rotation.y),Space.Self);
        transform.localRotation = b;
	}
}
