using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR27_CellComp : MonoBehaviour {
    public bool correct;
	// Use this for initialization
	void Start () {
        transform.GetComponent<LineRenderer>().SetPosition(0, transform.position);
        transform.GetComponent<LineRenderer>().SetPosition(1, transform.position);
    }
	
	// Update is called once per frame
	void Update () {
	}
}
