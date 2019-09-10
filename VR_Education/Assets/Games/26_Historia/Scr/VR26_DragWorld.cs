using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR26_DragWorld : MonoBehaviour {
    public GameObject floor;
    public GameObject referenceEmpty;
    public GameObject actualCreatedObj;
    public Vector3 clickPosition;
    public GameObject sphere;

    public bool canDrag;
    public float maxDistanceRaycast;
    private LineRenderer _ln;
    // Use this for initialization
    void Start () {
        clickPosition = new Vector3(0f, 0f, 0f);
        canDrag = false;
        _ln = transform.GetComponent<LineRenderer>();
        
    }
	
	// Update is called once per frame
	void Update () {


        _ln.SetPosition(0, transform.position);
        RaycastHit hito;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hito))
        {
            _ln.useWorldSpace = true;
            _ln.SetPosition(1, hito.point);
            sphere.transform.position = hito.point;
        }
        else
        {
            _ln.useWorldSpace = false;
            _ln.SetPosition(0, transform.localPosition);
            _ln.SetPosition(1, new Vector3(0f, 0f, 100f));
            sphere.transform.position = new Vector3(999f, 999f, 999f);
        }



#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.tag == "Hammer")
                {
                    canDrag = true;
                }

                if(canDrag == true)
                {
                    clickPosition = hit.point;
                }
            }





            if (clickPosition != new Vector3(0f, 0f, 0f))
            {
                
                clickPosition.y = 0f;
                clickPosition.z = 0f;

                if (actualCreatedObj == null)
                {
                    actualCreatedObj = Instantiate(referenceEmpty, clickPosition, transform.rotation);
                    floor.transform.SetParent(actualCreatedObj.transform);
                }


            }

            if(actualCreatedObj!= null)
            {
                actualCreatedObj.transform.position = new Vector3(clickPosition.x, clickPosition.y, clickPosition.z);
            }

        }
        else
        {
            if(actualCreatedObj != null)
            {
                floor.transform.parent = null;
                Destroy(actualCreatedObj);
                clickPosition = new Vector3(0f, 0f, 0f);
                canDrag = false;
            }
        }





#elif UNITY_ANDROID
        //ANDROID           -----------------------------------------------___________________-------------------------------------------_____________-------
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            Ray ray;
            RaycastHit hit;

            if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit))
            {
                if (hit.collider.gameObject.tag == "Hammer")
                {
                    canDrag = true;
                }

                if (canDrag == true)
                {
                    clickPosition = hit.point;
                }
            }


            if (clickPosition != new Vector3(0f, 0f, 0f))
            {

                clickPosition.y = 0f;
                clickPosition.z = 0f;

                if (actualCreatedObj == null)
                {
                    actualCreatedObj = Instantiate(referenceEmpty, clickPosition, transform.rotation);
                    floor.transform.SetParent(actualCreatedObj.transform);
                }


            }

            if (actualCreatedObj != null)
            {
                actualCreatedObj.transform.position = new Vector3(clickPosition.x, clickPosition.y, clickPosition.z);
            }

        }
        else
        {
            if (actualCreatedObj != null)
            {
                floor.transform.parent = null;
                Destroy(actualCreatedObj);
                clickPosition = new Vector3(0f, 0f, 0f);
                canDrag = false;
            }
        }


#endif


       
    }
}
