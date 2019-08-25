using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR21_HANDGRAB : MonoBehaviour {
    public GameObject grabbedobj;
    public bool canGrab;
    public bool grabbed;
    private float profundidade;
    private Quaternion rotacaoobj;

    // Use this for initialization
    void Start () {
        canGrab = false;
        grabbed = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (grabbed)
        {
            grabbedobj.transform.position = new Vector3(grabbedobj.transform.position.x, grabbedobj.transform.position.y, profundidade);
            transform.rotation = rotacaoobj;
        }

        if (!OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && grabbedobj != null)
        {
            profundidade = 0f;
            grabbedobj.transform.SetParent(null);
            grabbed = false;
            grabbedobj = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Grabable" && grabbed == false)
        {
            canGrab = true;
        }

        //		if (canGrab && Input.GetKey("left") && grabbed==false)
        //		{
        //			other.gameObject.transform.position = gameObject.transform.position;
        //			other.gameObject.transform.SetParent(gameObject.transform);
        //			canGrab = false;
        //			grabbed = true;
        //			grabbedobj = other.gameObject;
        //		}

        if (canGrab && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            profundidade = other.transform.position.z;
            rotacaoobj = other.transform.transform.rotation;
            other.transform.SetParent(transform);
            canGrab = false;
            grabbed = true;
            grabbedobj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (grabbed == false)
        {
            canGrab = false;
        }
    }

    public bool getGrabbed()
    {
        return (grabbed);
    }

    public void outsideGrab(GameObject other)
    {
        canGrab = false;
        grabbed = true;
        grabbedobj = other;
    }
}
