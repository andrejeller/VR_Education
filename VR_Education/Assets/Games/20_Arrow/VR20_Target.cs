using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR20_Target : MonoBehaviour {


	private void OnCollisionEnter(Collision collision) {
		gameObject.transform.DOShakeRotation(0.3f, new Vector3(10, 5, 0), 3, 5, true);

	}

}
