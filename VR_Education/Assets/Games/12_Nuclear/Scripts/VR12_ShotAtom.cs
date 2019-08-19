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
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.S))
        {
            var a = Instantiate(objshotatom, transform.position,transform.rotation);
            a.GetComponent<Rigidbody>().AddForce(1000*a.transform.forward);
        }
	}
}
