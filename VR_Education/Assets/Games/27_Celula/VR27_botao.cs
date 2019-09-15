using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VR27_botao : MonoBehaviour {
    public bool pareado;
    public Text txt;
    public GameObject ComponenteCorreto;
	// Use this for initialization
	void Start () {
        pareado = false;
        
	}
	
	// Update is called once per frame
	void Update () {
		if (pareado)
        {
            txt.enabled = true;
            gameObject.GetComponent<Renderer>().materials[1].color = Color.green;
        }
	}
}
