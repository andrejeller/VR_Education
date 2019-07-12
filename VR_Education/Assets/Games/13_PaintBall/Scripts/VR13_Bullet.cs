using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VR13_Bullet : MonoBehaviour
{
	private bool alreadyColide = false;
	private GameObject canvasObj;
	
	// Use this for initialization
	void Start () {
		canvasObj = GameObject.Find("Canvas");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Grabable"&& !alreadyColide)
		{
			alreadyColide = true;
			collision.gameObject.GetComponent<Renderer>().materials[1].color = GetComponent<Renderer>().material.color;
			canvasObj.GetComponent<VR13_Canvas>().correctPercent(collision.gameObject.GetComponent<VR13_PixelCanvas>().compareColors());
			Destroy(gameObject);
		}
		else if (collision.gameObject.tag == "Hand")
		{
			canvasObj.GetComponent<VR13_Canvas>().GetImageColors(true);
			Destroy(gameObject);
			VR13_Bullet[] bulletInScreen;

			bulletInScreen = GameObject.FindObjectsOfType<VR13_Bullet>();
			var clones = GameObject.FindGameObjectsWithTag ("Grabable");
			for (int clone =0; clone < clones.Length ; clone++){
				Destroy(clones[clone]);
			}
		}
	}
	
	
	private void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Grabable Special") Destroy(gameObject);
	}
}
