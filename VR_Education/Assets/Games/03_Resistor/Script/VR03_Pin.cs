using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR03_Pin : MonoBehaviour
{
	public int pinnedvalue;

	public bool pinned = false;

	private GameObject pinnedObj = null;
	public GameObject playerHand = null;
	
	void Start () {
	}
	
	
	void Update () {
		if (pinned)
		{
			if (pinnedObj.GetComponent<VR03_Grabable>().grabbed == true)
			{
				pinnedvalue = 0;
				pinned = false;
				pinnedObj.GetComponent<VR03_Grabable>().pinned = false;
				pinnedObj = null;
			}
			else
			{
				pinnedvalue= pinnedObj.GetComponent<VR03_Grabable>().truevalue;
			}
		}
	
	}
	private void OnTriggerStay(Collider other)
	{	
		if (other.gameObject.tag == "Grabable" && pinned==false && pinnedObj==null && other.GetComponent<VR03_Grabable>().pinned == false && other.GetComponent<VR03_Grabable>().grabbed == false && playerHand.GetComponent<VR03_GrabAndPin>().grabbed == false)
		{
			other.GetComponent<VR03_Grabable>().changeParent(gameObject);
			pinned = true;
			pinnedObj = other.gameObject;
		}
	}

	public int correctPin()
	{
		if (pinnedvalue != null)
		{
			return (pinnedvalue);
		}
		else
		{
			return (0);
		}
	}
}