using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR04_SpawnObj : MonoBehaviour
{

	// Use this for initialization

	public GameObject[] objetos = new GameObject[5];
	public AudioClip[] clip = new AudioClip[2];
	private int countNumber = 0;
	private GameObject currentObj;
	private bool hisGuilty;
	private VR04_Grabable currentObjScr;
	public GameObject woodButtonObj;

	void Start()
	{
		instancePrefab();
	}

	// Update is called once per frame
	void Update()
	{
		if (currentObjScr.grabbed == false)
		{
			currentObj.transform.position = transform.position;
		}

		if (Input.GetKeyDown(KeyCode.Z))
		{
			compareResult(true);
		}
		if (Input.GetKeyDown(KeyCode.X))
		{
			compareResult(false);
		}
	}

	private void instancePrefab()
	{
		if (currentObj != null)
		{
			Destroy(currentObj);
		}

		

		currentObj = Instantiate(objetos[countNumber], transform.position, objetos[countNumber].transform.rotation);
		hisGuilty = currentObj.GetComponent<VR04_Item>().getGuilty();
		currentObjScr = currentObj.GetComponent<VR04_Grabable>();
		countNumber++;
		if (countNumber > 4)
		{
			countNumber = 0;
		}
	}

	public void compareResult(bool inputHammer)
	{
		if (inputHammer == hisGuilty)
		{
			woodButtonObj.GetComponent<VR04_WoodButton>().playSound(2);
		}
		else
		{
			woodButtonObj.GetComponent<VR04_WoodButton>().playSound(3);
		}
		instancePrefab();
	}
	
}
