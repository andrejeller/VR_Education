using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VR04_HandGrab : MonoBehaviour {

	public GameObject grabbedobj;
	public GameObject teste;
	public bool canGrab;
	public bool grabbed;
	void Start()
	{
	
		canGrab = false;
		grabbed = false;
		
		//teste.gameObject.transform.position = gameObject.transform.position;
		//teste.gameObject.transform.SetParent(gameObject.transform);
	}

	// Update is called once per frame
	void Update()
	{
//		if (Input.GetKey("right"))
//		{
//			
//			transform.Rotate(0,0,5,Space.Self);
//		}
//		if (!Input.GetKey("left") && grabbedobj!=null)
//		{
//			grabbed = false;
//			grabbedobj.transform.parent = null;
//			grabbedobj = null;
//		}
		
		if (!OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)&& grabbedobj!=null)
		{	
			grabbedobj.GetComponent<VR04_Grabable>().nullParent();
			grabbed = false;
			grabbedobj = null;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		
		if (other.gameObject.tag == "Grabable" && grabbed==false)
		{
			canGrab = true;
		}

		if (OVRInput.Get(OVRInput.Button.One))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		
//		if (canGrab && Input.GetKey("left") && grabbed==false)
//		{
//			other.gameObject.transform.position = gameObject.transform.position;
//			other.gameObject.transform.SetParent(gameObject.transform);
//			canGrab = false;
//			grabbed = true;
//			grabbedobj = other.gameObject;
//		}

		if (canGrab && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
		{
			other.GetComponent<VR04_Grabable>().changeParent(gameObject);
			canGrab = false;
			grabbed = true;
			grabbedobj = other.gameObject;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (grabbed == false)
		{
			canGrab = false;
		}
	}

	public bool getGrabbed()
	{
		return (grabbed);
	}

	public void outsideGrab(GameObject other)
	{
		canGrab = false;
		grabbed = true;
		grabbedobj = other;
	}
	
}
