using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR12_ShotAtom : MonoBehaviour {
    public GameObject objshotatom;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKey(KeyCode.S))
        {
            var a = Instantiate(objshotatom);
            a.GetComponent<Rigidbody>().AddForce(10*transform.forward);
        }
	}
}
