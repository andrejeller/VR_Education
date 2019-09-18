using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR28_Pipa : MonoBehaviour {
    public GameObject playerHandPivot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = playerHandPivot.transform.position;
	}
}
