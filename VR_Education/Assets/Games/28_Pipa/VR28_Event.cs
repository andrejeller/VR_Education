using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR28_Event : MonoBehaviour {
    private float currentTime;
    public GameObject lamp0;
    public GameObject lamp1;
    public GameObject thunderSprite;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if(currentTime >= 5f)
        {
            lamp0.transform.GetComponent<Light>().intensity = 0.71f;
            lamp1.transform.GetComponent<Light>().intensity = 0.71f;
            currentTime = -0.1f;
        }

        if (currentTime < 0)
        {
            thunderSprite.SetActive(true);
        }
        else
        {
            thunderSprite.SetActive(false);
        }
    }
	
}
