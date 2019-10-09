using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR30_DrinkPolen : MonoBehaviour {

    private bool alreadyDrink;
    private float drinktime = 2f;
   


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && !alreadyDrink)
        {
            other.GetComponent<VR30_BeeMove>().canudoPlay();
            drinktime -= Time.deltaTime;
            if (drinktime < 0)
            {
                alreadyDrink = true;
                gameObject.SetActive(false);
                other.GetComponent<AudioSource>().Stop();
            }

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            other.GetComponent<AudioSource>().Stop();
    }
}
