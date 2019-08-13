using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watershot : MonoBehaviour {
    public GameObject boxColidWater;
    public float spd;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        var a = Instantiate(boxColidWater,transform.position,transform.rotation);
        a.GetComponent<Rigidbody>().AddForce(transform.forward * spd);
    }
}
