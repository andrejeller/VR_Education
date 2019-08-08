using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR04_chair : MonoBehaviour {

	// Use this for initialization
	public Transform parentRotation;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//transform.rotation = Quaternion.Euler(transform.localRotation.x, parentRotation.eulerAngles.y, transform.localRotation.z);
		
		Vector3 newRotation = new Vector3(transform.eulerAngles.x, parentRotation.eulerAngles.y, transform.eulerAngles.z);
		transform.localRotation =  Quaternion.Euler(newRotation);
	}
}
