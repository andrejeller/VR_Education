using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR04_Item : MonoBehaviour
{

	public bool guilty;
	private VR04_Grabable grabbedScr;


	void Start ()
	{
		grabbedScr = GetComponent<VR04_Grabable>();
	}
	
	public bool getGuilty()
	{
		return (guilty);
	}
	
	void Update()
	{
		if (grabbedScr.grabbed == true) return;
		transform.Rotate(0, 1, 0,Space.World);
	}
}
