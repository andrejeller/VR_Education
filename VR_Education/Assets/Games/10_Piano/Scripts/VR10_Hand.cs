using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class VR10_Hand : MonoBehaviour
{
	public GameObject trueHand;

	private float initialHeight;
	// Use this for initialization
	void Start ()
	{
		initialHeight = transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float convertYtoXPos = Mathf.Sin(trueHand.transform.rotation.eulerAngles.y * Mathf.Deg2Rad)*5.98f;
		float convertXtoYPos =  Mathf.Sin(trueHand.transform.rotation.eulerAngles.x * Mathf.Deg2Rad)*2.2f;
		transform.position = new Vector3(convertYtoXPos,initialHeight-convertXtoYPos,transform.position.z);
	}
}