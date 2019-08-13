using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watercan : MonoBehaviour {
    public GameObject partsysobj;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(transform.eulerAngles.z >= 13f && transform.eulerAngles.z <= 45f)
        {
            partsysobj.SetActive(true);
        }
        else
        {
            partsysobj.SetActive(false);
        }
	}
}
