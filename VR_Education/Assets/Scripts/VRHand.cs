using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VRHand:MonoBehaviour {

	public Transform HandAnchor;[Space]
	public Transform[] fingers = new Transform[6]; //0-Palma, 1-PreDEdao, 2Dedao, 3...
	public Vector3[] ClosedPositions = new Vector3[6];
	public Vector3[] ClosedRotaions = new Vector3[6];

	private bool up, down;
	private float time = 0.2f;
	private Transform Anchor { get { return transform.parent.transform.parent; } set { transform.parent.transform.parent = value; } }




	private void Update() {

		if (Input.GetKeyDown(KeyCode.Space) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
			CloseHand();
		if (Input.GetKeyUp(KeyCode.Space) || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
			OpenHand();

		if (!down && HandAnchor.rotation.eulerAngles.x > 300 && HandAnchor.rotation.eulerAngles.x < 315) {
			up = true;
		}
		/*if (!up && HandAnchor.rotation.eulerAngles.x > 57 && HandAnchor.rotation.eulerAngles.x < 60) {
			down = true;
		}*/

		if (up && HandAnchor.rotation.eulerAngles.x > 312 && HandAnchor.rotation.eulerAngles.x < 315) {
			up = false;
		}
		/*if (down && HandAnchor.rotation.eulerAngles.x < 60 && HandAnchor.rotation.eulerAngles.x > 57) {
			down = false;
		}*/


		if (up || down) {
			Anchor = null;
			transform.parent.rotation = HandAnchor.rotation;
		}

		if (!Anchor && !up && !down) Anchor = HandAnchor;


		Debug.Log(HandAnchor.rotation.eulerAngles.x);


	}


	private void CloseHand() {
		for (int i = 0; i < 7; i++) {
			fingers[i].DOLocalMove(ClosedPositions[i], time, false);
			fingers[i].DOLocalRotate(ClosedRotaions[i], time, RotateMode.Fast);
		}

	}

	private void OpenHand() {
		for (int i = 0; i < 7; i++) {
			fingers[i].DOLocalMove(Vector3.zero, time, false);
			fingers[i].DOLocalRotate(Vector3.zero, time, RotateMode.Fast);
		}

	}
}
