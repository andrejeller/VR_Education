using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR12_AtomSpin : MonoBehaviour {
    public GameObject[] eletrons = new GameObject[4];
    public float spd;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 4; i++)
        {
            eletrons[i].transform.localScale = Vector3.one * (1f - i*0.05f);
        }
    }
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < 4; i++)
        {
            var i_spd = (spd * (1 - 0.035f*i));
            eletrons[i].transform.Rotate(i_spd * Time.deltaTime, i_spd * Time.deltaTime, i_spd * Time.deltaTime, Space.Self);
        }
	}
}
