using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VR25_Control : MonoBehaviour
{
    public GameObject currentOBJ;
    public Text textobj;
    
    private float alphaTextColor;
    private Vector3 colors;
    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && currentOBJ != null)
        {
            currentOBJ.GetComponent<MeshRenderer>().enabled = true;
            textobj.text = currentOBJ.name;
            alphaTextColor = 1f;
           
            var a = currentOBJ.GetComponent<VR25_Color>().corzinha;
            colors = new Vector3(a.r, a.g, a.b);

            currentOBJ = null;
        }


        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && currentOBJ != null)
        {
            currentOBJ.GetComponent<MeshRenderer>().enabled = true;
            textobj.text = currentOBJ.name;
            alphaTextColor = 1f;
            
            var a = currentOBJ.GetComponent<VR25_Color>().corzinha;
            colors = new Vector3(a.r, a.g, a.b);

            currentOBJ = null;
        }

        textobj.color = new Color(colors.x, colors.y, colors.z, alphaTextColor);
        if (alphaTextColor > 0f) alphaTextColor -= 0.25f * Time.deltaTime;
        

        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("BATI EM ALGO EM");
        if (currentOBJ == null)
        {
            currentOBJ = other.gameObject;
            Debug.Log("AE FUNCIONO EU ACHO");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (currentOBJ == other.gameObject) currentOBJ = null;
    }

}

