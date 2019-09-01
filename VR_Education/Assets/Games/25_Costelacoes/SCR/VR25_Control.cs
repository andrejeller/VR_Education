using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VR25_Control : MonoBehaviour
{
    public GameObject currentOBJ;
    public Text textobj;
    private List<GameObject> listinha;
    private float alphaTextColor;
    private Vector3 colors;
    // Use this for initialization
    void Start()
    {
        listinha = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && currentOBJ != null)
        {
            currentOBJ.GetComponent<MeshRenderer>().enabled = true;
            textobj.text = currentOBJ.name;
            alphaTextColor = 1f;
            listinha.Add(currentOBJ);
            var a = currentOBJ.GetComponent<VR25_Color>().corzinha;
            colors = new Vector3(a.r, a.g, a.b);

            currentOBJ = null;
        }

        textobj.color = new Color(colors.x, colors.y, colors.z, alphaTextColor);
        if (alphaTextColor > 0f) alphaTextColor -= 0.25f * Time.deltaTime;
        

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (currentOBJ == null && listinha.Contains(other.gameObject) == false)
        {
            currentOBJ = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (currentOBJ == other.gameObject) currentOBJ = null;
    }

}

