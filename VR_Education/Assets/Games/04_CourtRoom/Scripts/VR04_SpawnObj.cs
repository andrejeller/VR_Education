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

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void instancePrefab()
	{
		if (currentObj != null)
		{
			Destroy(currentObj);
		}

		if (countNumber > objetos.Length)
		{
			countNumber = 0;
		}

		currentObj = Instantiate(objetos[countNumber], transform.position, Quaternion.identity);
		hisGuilty = currentObj.GetComponent<VR04_Item>().getGuilty();
		countNumber++;
	}

	void compareResult(bool inputHammer)
	{
		if (inputHammer == hisGuilty)
		{
			AudioSource.PlayClipAtPoint(clip[0], transform.position);
		}
		else
		{
			AudioSource.PlayClipAtPoint(clip[1], transform.position);
		}
	}
	
}
