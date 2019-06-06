using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR06_Seringa:MonoBehaviour {

	// -0.11 <-> -0.15
	public GameObject cabo;
	public Transform ponta;
	private float moveTime = 0.147f;

	

	public void Press() {
		cabo.transform.DOLocalMoveZ(-0.11f, moveTime, false);
	}

	public void Release() {
		cabo.transform.DOLocalMoveZ(-0.14f, moveTime, false);
	}

}
