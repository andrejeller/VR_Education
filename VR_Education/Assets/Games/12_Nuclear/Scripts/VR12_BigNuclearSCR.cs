using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR12_BigNuclearSCR : MonoBehaviour {
    public GameObject player;
    public bool destroy = false;
    public GameObject playeratomgun;
    public GameObject explosion;
    public GameObject part1;
    public GameObject part2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (destroy)
        {
            Destroy(gameObject);
            player.transform.position = new Vector3(114f, 6.81f, 313.2f);
            player.transform.rotation = Quaternion.identity;
            player.transform.Rotate(0f, 240f, 0f);
            playeratomgun.SetActive(false);
            explosion.SetActive(true);
            part1.SetActive(false);
            part2.SetActive(false);
        }
	}
}
