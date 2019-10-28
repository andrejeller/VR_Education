using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR30_BeeMove : MonoBehaviour {

    public float flyForce;
    public float frontFlyForce;
    public AudioClip canudo;
    public GameObject centerCamera;
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

//#if UNITY_EDITOR
        //if (Input.GetKey(KeyCode.Space))
        //{
           // rb.AddForce(centerCamera.transform.up * flyForce);
           // rb.AddForce(centerCamera.transform.forward * frontFlyForce);
        //}


        //y = Input.GetAxis("Mouse X");
        //x = Input.GetAxis("Mouse Y");
        //rotateValue = new Vector3(x, y * -1, 0);
        //transform.eulerAngles = transform.eulerAngles - rotateValue;

        //#elif UNITY_ANDROID

        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            rb.AddForce(new Vector3(0f, 1f, 0f) * flyForce);
            //ad.PlayOneShot(canudo);
            rb.AddForce(centerCamera.transform.up * flyForce);
            rb.AddForce(centerCamera.transform.forward * frontFlyForce);
        }
//#endif
    }

    public void canudoPlay()
    {
        if (!ad.isPlaying)
        {
            ad.PlayOneShot(canudo);
        }
    }
}
