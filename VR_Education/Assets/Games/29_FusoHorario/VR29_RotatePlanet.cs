using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VR29_RotatePlanet : MonoBehaviour {

    Quaternion planetRotation;
    public float dist = 400;
    public float targetRadius = 100;
    public float dayTime;
    public float divisionScale;

    public Text textTime;
    void Start () {
        planetRotation = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1"))
        {


            float xMove = Input.GetAxis("Mouse X");
            float yMove = Input.GetAxis("Mouse Y");

            if (xMove != 0 || yMove != 0)
            {
                float rotateSensitivity = Mathf.Min(2f, (float)((dist - targetRadius) / targetRadius) * 1.2f);
                planetRotation *= Quaternion.AngleAxis(rotateSensitivity * -xMove, Vector3.up);
            }

            transform.rotation = planetRotation;
        }


        dayTime = Mathf.Floor(UnityEditor.TransformUtils.GetInspectorRotation(transform).y/ divisionScale);
        if (dayTime == -12f) dayTime = 12f;
        textTime.text = ("Fuso Horario atual: "+dayTime+" UTC.");
    }
}
