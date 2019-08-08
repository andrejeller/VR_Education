using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;
using Random = UnityEngine.Random;

public class VR04_Grabable : MonoBehaviour
{
	public bool grabbed = false;
	private Rigidbody rb;
	private float destroytime;
	
	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{

/*		if (!grabbed && !pinned)
		{
			destroytime += Time.deltaTime;
			if (destroytime >= 2.0f)
			{
				Destroy(gameObject);
			}
		}*/
		
	}

	public void changeParent(GameObject obj)
	{
			//destroytime = 0;
			
			transform.SetParent(obj.gameObject.transform.transform);
			grabbed = true;
			transform.localPosition = new Vector3(0.01630002f,0.01789999f,0.01879998f);
			Vector3 newRotation = new Vector3(1.627f,-230.61f,103.136f);
			transform.localRotation =  Quaternion.Euler(newRotation);
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
	}

	public void nullParent()
	{
		//rb.AddForce(pinnedObj.transform.forward*300);
		rb.constraints = RigidbodyConstraints.None;
		transform.parent = null;
		grabbed = false;
		if (gameObject.tag == "Grabable Special")
		{
			transform.position= new Vector3(-0.0012f,2.146484f,-5.307129f);
		}
	}
}
