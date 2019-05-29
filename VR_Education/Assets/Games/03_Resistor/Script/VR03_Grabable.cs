using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;
using Random = UnityEngine.Random;

public class VR03_Grabable : MonoBehaviour
{

	public bool grabbed = false;
	public bool pinned = false;
	public GameObject pinnedObj;
	private Rigidbody rb;
	private Material[] mats;
	private float destroytime;
	public int[] value;
	private Renderer render;
	public int truevalue;
	
	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		render = GetComponent<Renderer>();

		value = new int[3];
	
		Color color;
		for (int i = 0; i< 3;i++)
		{
			if (i != 0)
			{
				value[i] = Random.Range(0, 10);
			}
			else
			{
				value[i] = Random.Range(0, 2);
			}
			switch (value[i])
			{
				case 0: render.materials[i+3].color = new Color(0f,0f,0f);
					break;
				case 1: render.materials[i+3].color = new Color(0.6f,0.39f,0.2f);
					break;
				case 2: render.materials[i+3].color = new Color(1.0f,0.0f,0.24705882f);
					break;
				case 3: render.materials[i+3].color = new Color(0.99607843f,0.6f,0.0f);
					break;
				case 4: render.materials[i+3].color = new Color(1f,1f,0f);
					break;
				case 5: render.materials[i+3].color = new Color(0.0f,0.6862745f,0.3137255f);
					break;
				case 6: render.materials[i+3].color = new Color(0.003921569f,0.4f,1.0f);
					break;
				case 7: render.materials[i+3].color = new Color(0.8039216f,0.4f,1.0f);
					break;
				case 8: render.materials[i+3].color = new Color(0.5764706f,0.5764706f,0.5764706f);
					break;
				case 9: render.materials[i+3].color = new Color(1f,1f,1f);
					break;
			}
		}
		
		string calculos = value[0].ToString() + value[1].ToString();
		truevalue = int.Parse(calculos)*10^value[2];
	}

	private void Update()
	{

		if (!grabbed && !pinned)
		{
			destroytime += Time.deltaTime;
			if (destroytime >= 2.0f)
			{
				Destroy(gameObject);
			}
		}
		
	}

	public void changeParent(GameObject obj)
	{
		if (obj.gameObject.tag == "Hand")
		{
			if (pinned == true)
			{
				pinned = false;
				pinnedObj = null;
				transform.parent = null;
			}

			destroytime = 0;
			pinnedObj = obj;
			transform.SetParent(obj.gameObject.transform.transform);
			
			pinned = false;
			grabbed = true;
			transform.localPosition = new Vector3(0f,0f,0f);
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
		}
		else
		{
			destroytime = 0;
			pinnedObj = obj;
			gameObject.transform.SetParent(obj.gameObject.transform);
			gameObject.transform.localPosition = new Vector3(0f,0f,0f);
			gameObject.transform.localRotation = Quaternion.identity;
			//pinnedObj.gameObject.transform.localScale = new Vector3(0.1136936f,0.1826697f,0.1109335f);
			rb.angularVelocity = Vector3.zero; 
			rb.velocity = Vector3.zero;
			rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
			pinned = true;
		}
	}

	public void nullParent()
	{
		if (pinnedObj.gameObject.tag == "Hand")
		{
			rb.AddForce(pinnedObj.transform.forward*300);
			rb.constraints = RigidbodyConstraints.None;
		}
		
		transform.parent = null;
		grabbed = false;
		pinned = false;
		pinnedObj = null;
	}
}
