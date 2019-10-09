using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR30_BeeMove : MonoBehaviour {

    public float flyForce;
    public float frontFlyForce;
    public AudioClip canudo;
    private AudioSource ad;


    private float x;
    private float y;
    private Vector3 rotateValue;
    

    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        ad = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * flyForce);
            rb.AddForce(transform.forward * frontFlyForce);
        }


        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotateValue = new Vector3(x, y * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;


    }

    public void canudoPlay()
    {
        if (!ad.isPlaying)
        {
            ad.PlayOneShot(canudo);
        }
    }
}
