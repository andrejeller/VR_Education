using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR20_Arrow : MonoBehaviour {

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Wall") {
			Destroy(gameObject);
		}
	}

}
