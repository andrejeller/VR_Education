using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR06_Tiro:MonoBehaviour {


	public void shoteME() {
		GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
	}



	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "ParedeSanguinea")
			Destroy(gameObject);
		else if (collision.gameObject.tag == "Virus") {
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}

	}

}
