using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR21_FluxoCheck : MonoBehaviour {
    public GameObject[] ListOfOBJ;
    public GameObject ledobj;
    public GameObject lamp;
    public GameObject robot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var a = true;

        for(int i =0; i < ListOfOBJ.Length; i++)
        {
            if (ListOfOBJ[i].GetComponent<VR21_FluxoCollideOrder>().correct == false)
            {
                a = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.A)) { a = true; }

        if (a == true)
        {
            ledobj.GetComponent<Renderer>().material.color = Color.green;
            lamp.SetActive(true);
            if(robot.GetComponent<RobotTestScriptFree>().stepAnimationOrder == 0)
            {
                robot.GetComponent<RobotTestScriptFree>().stepAnimationOrder = 1;
            }
            
        }
	}
}
