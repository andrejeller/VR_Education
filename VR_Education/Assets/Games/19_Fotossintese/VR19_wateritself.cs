using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR19_wateritself : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y< 2.35f)
        {
            Destroy(gameObject);
        }
	}
}
