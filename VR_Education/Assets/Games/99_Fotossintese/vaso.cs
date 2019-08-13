using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaso : MonoBehaviour {
    bool alreadyColide = false;
    public GameObject plant;
    private Transform plantthings;
    private float inc = 0.005f;
    
    // Use this for initialization
    void Start () {
        plantthings = plant.GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update () {
        if (alreadyColide)
        {
            //dothing
            //view_xview[0] += ((x-(view_wview[0]/2)) - view_xview[0]) * 0.06

            var aa = plantthings.localScale.x + ((1 - plantthings.localScale.y) - plantthings.localScale.y) * inc;
            plantthings.localScale = new Vector3(aa, aa, aa);
            //plantthings.Rotate(transform.upper)
            inc += inc/100;
            if (inc > 1f) inc = 1f;
            alreadyColide = false;

        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hammer" && !alreadyColide)
        {
            alreadyColide = true;
            Destroy(other.gameObject);
        }
    }
}
