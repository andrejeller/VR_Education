using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VR04_WoodButton : MonoBehaviour {
	public AudioClip[] clip = new AudioClip[2];

	public GameObject spawnPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Hammer")
		{
			AudioSource.PlayClipAtPoint(clip[0], transform.position);
			spawnPoint.GetComponent<VR04_SpawnObj>().compareResult(true);
		}
		else if(other.gameObject.tag == "Hammer Toy")
		{
			AudioSource.PlayClipAtPoint(clip[1], transform.position);
			spawnPoint.GetComponent<VR04_SpawnObj>().compareResult(false);
		}
	}
}