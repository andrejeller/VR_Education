using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VR27_botao : MonoBehaviour {
    private bool pareado;
    private Text txt;
    
	// Use this for initialization
	void Start () {
        pareado = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (pareado)
        {
            txt.enabled = true;
        }
	}
}
