using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR27_Player : MonoBehaviour {

    public GameObject target;
    private LineRenderer _ln;



    // Use this for initialization
    void Start () {
        _ln = transform.GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        SelectObject();
	}




    void SelectObject()
    {

        _ln.SetPosition(0, transform.position);
        RaycastHit hito;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hito))
        {
            _ln.useWorldSpace = true;
            _ln.SetPosition(1, hito.point);
        }
        else
        {
            _ln.useWorldSpace = false;
            _ln.SetPosition(0, transform.localPosition);
            _ln.SetPosition(1, new Vector3(0f, 0f, 100f));
        }








#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.tag == "Grabable" && target == null)
                {
                    if (!hit.collider.gameObject.GetComponent<VR27_CellComp>().correct) target = hit.collider.gameObject;
                }

                if (target != null)
                {
                    target.GetComponent<LineRenderer>().SetPosition(1, hit.point);
                }
            }


        }

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.tag == "Grabable Special" && target != null)
                {
                    var _a = hit.collider.gameObject.GetComponent<VR27_botao>();

                    if (_a.ComponenteCorreto == target)
                    {
                        _a.pareado = true;
                        target.GetComponent<VR27_CellComp>().correct = true;
                        Debug.Log("deu certo");

                        target.GetComponent<LineRenderer>().SetPosition(1, hit.collider.transform.position);
                    }
                    else target.GetComponent<LineRenderer>().SetPosition(1, target.transform.position);
                }
                else target.GetComponent<LineRenderer>().SetPosition(1, target.transform.position);
            }

            target = null;
        }









        #elif UNITY_ANDROID

        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            Ray ray;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {

                if (hit.collider.tag == "Grabable" && target == null)
                {
                    if (!hit.collider.gameObject.GetComponent<VR27_CellComp>().correct) target = hit.collider.gameObject;
                }

                if (target != null)
                {
                    target.GetComponent<LineRenderer>().SetPosition(1, hit.point);
                }
            }


        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            Ray ray;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {

                if (hit.collider.tag == "Grabable Special" && target != null)
                {
                    var _a = hit.collider.gameObject.GetComponent<VR27_botao>();

                    if (_a.ComponenteCorreto == target)
                    {
                        _a.pareado = true;
                        target.GetComponent<VR27_CellComp>().correct = true;
                        Debug.Log("deu certo");

                        target.GetComponent<LineRenderer>().SetPosition(1, hit.collider.transform.position);
                    }
                    else target.GetComponent<LineRenderer>().SetPosition(1, target.transform.position);
                }
                else target.GetComponent<LineRenderer>().SetPosition(1, target.transform.position);
            }

            target = null;
        }

        #endif


    }


}
