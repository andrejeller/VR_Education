using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR04_xRay : MonoBehaviour
{

	public GameObject hand;

	private VR04_HandGrab handScript;
	
	// Use this for initialization
	void Start () {
		handScript  = hand.GetComponent<VR04_HandGrab>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
		{
			if (handScript.getGrabbed()==false)
			{
				GameObject aaaaaaaaa = GameObject.FindWithTag("Grabable Special");
				aaaaaaaaa.GetComponent<VR04_Grabable>().changeParent(hand);
					handScript.outsideGrab(aaaaaaaaa.gameObject);
			}

		}
	}
	
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Grabable Special" && handScript.getGrabbed()==false)
		{
			if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
			{
				other.GetComponent<VR04_Grabable>().changeParent(hand);
				handScript.outsideGrab(other.gameObject);
			}
		}
	}
}
