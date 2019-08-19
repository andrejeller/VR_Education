using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR12_ArrowPointCode : MonoBehaviour {
    public GameObject bomb;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(bomb.transform);
	}
}
