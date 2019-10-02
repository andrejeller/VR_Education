using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR21_FluxoCollideOrder : MonoBehaviour {
    public GameObject CorrectColider;
    public bool correct = false;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == CorrectColider)
        {
            correct = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == CorrectColider)
        {
            correct = false;
        }
    }
}
