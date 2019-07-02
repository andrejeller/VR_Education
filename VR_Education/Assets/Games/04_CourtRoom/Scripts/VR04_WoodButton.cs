using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VR04_WoodButton : MonoBehaviour {
	public AudioClip[] clip = new AudioClip[4];

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
			playSound(0);
			spawnPoint.GetComponent<VR04_SpawnObj>().compareResult(true);
		}
		else if(other.gameObject.tag == "Hammer Toy")
		{
			playSound(1);
			spawnPoint.GetComponent<VR04_SpawnObj>().compareResult(false);
		}
	}

	public void playSound(int o)
	{
		AudioSource.PlayClipAtPoint(clip[o], transform.position);
	}
}