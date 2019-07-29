using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR11_LIGHTS : MonoBehaviour
{

    public GameObject objLamp1;
    public GameObject objLamp2;
    public GameObject objLamp3;

    public GameObject Lamp1;
    public GameObject Lamp11;

    public GameObject Lamp2;
    public GameObject Lamp22;

    public GameObject Lamp3;
    public GameObject Lamp33;

    private GameObject LightSelected;
    private GameObject TransformSelected;
    private GameObject LampSelected;
    private GameObject LampSelected1;

    private Vector2 Axis;

    private int LightNumber = 1;

    private int TranformMode = 1;

    // Update is called once per frame
    void Update()
    {
        // Outline Light 1
        if (LightNumber == 1)
        {
            //light1.GetComponent<Outline>().enabled = true;
        }
        else
        {
            //.GetComponent<Outline>().enabled = false;
        }

        // Outline Light 2
        if (LightNumber == 2)
        {
            //light2.GetComponent<Outline>().enabled = true;
        }
        else
        {
            //light2.GetComponent<Outline>().enabled = false;
        }

        // Outline Light 3
        if (LightNumber == 3)
        {
            //light3.GetComponent<Outline>().enabled = true;
        }
        else
        {
            //light3.GetComponent<Outline>().enabled = false;
        }

        // Define Selected Light
        if (LightNumber == 1)
        {
            TransformSelected = objLamp1;
            LampSelected = Lamp1;
            LampSelected1 = Lamp11;
        }
        else if (LightNumber == 2)
        {
            TransformSelected = objLamp2;
            LampSelected = Lamp2;
            LampSelected1 = Lamp22;
        }
        else if (LightNumber == 3)
        {
            TransformSelected = objLamp3;
            LampSelected = Lamp3;
            LampSelected1 = Lamp33;
        }

        // Select other light
        if (Input.GetKeyDown("space") || OVRInput.GetDown(OVRInput.Button.One))
        {
            LightNumber += 1;
        }

        if (LightNumber > 3)
        {
            LightNumber = 1;
        }

        // Change Tranform Mode
        if (Input.GetKeyDown("c") || OVRInput.GetDown(OVRInput.Button.Back))
        {
            TranformMode += 1;
        }

        if (TranformMode > 3)
        {
            TranformMode = 1;
        }

        Axis = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        if (TranformMode == 1)
        {
            // Move Selected Light 
            MoveLight(TransformSelected, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            MoveLight(TransformSelected, Axis.x, Axis.y);
        }
        else if (TranformMode == 2)
        {
            //Rotate Selected Light 
            RotateLight(TransformSelected, Input.GetAxis("Horizontal"));
            RotateLight(TransformSelected, Axis.x);
        }
        else if (TranformMode == 3)
        {
            //Change Intensity Light 
            IntensityLamp(LampSelected, Input.GetAxis("Vertical"));
            IntensityLamp(LampSelected, Axis.y);

            IntensityLamp(LampSelected1, Input.GetAxis("Vertical"));
            IntensityLamp(LampSelected1, Axis.y);
        }

        //Debug
        Debug.Log(LightNumber);
    }


    // Move Selected Light
    private void MoveLight(GameObject LightSelected, float xMov, float YMov)
    {
        LightSelected.transform.localPosition = (LightSelected.transform.localPosition + ((new Vector3(xMov, 0, YMov)) / 20));
    }

    //Rotate Selected Light 
    private void RotateLight(GameObject LightSelected, float ZRotation)
    {
        LightSelected.transform.Rotate(Vector3.up * ZRotation);
    }

    private void IntensityLamp(GameObject LampSelected, float Intensity)
    {
        LampSelected.GetComponent<Light>().intensity += (Intensity / 5);
    }
}
