using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR12_Bulletscr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.localScale = Vector3.one * (transform.localScale.x+ 0.005f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grabable Special")
        {
            var b = other.GetComponent<VR12_BigNuclearSCR>();
            if(b.destroy == false)
            {
                Destroy(gameObject);
                b.destroy = true;
            }
        }
    }
}
