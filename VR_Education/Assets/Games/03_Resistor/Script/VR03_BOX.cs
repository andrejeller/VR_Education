using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR03_BOX : MonoBehaviour
{

// Use this for initialization
	public GameObject resistPrefab;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Hand")
		{
			if (other.GetComponent<VR03_GrabAndPin>().grabbed == false && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
			{
				Instantiate(resistPrefab, other.gameObject.transform.position, Quaternion.identity);
			}
		}
	}

	private void OnCollisionEnter(Collision collision) {
	}
}
