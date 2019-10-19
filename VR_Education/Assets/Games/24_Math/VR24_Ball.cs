using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR24_Ball : MonoBehaviour {

	void Update () {
		if (transform.position.y <= -10.0f) {
			Destroy(gameObject);
		}
	}
}
