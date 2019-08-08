using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectBE5:MonoBehaviour, IInteractable {

	// Start is called before the first frame update
	private Vector3 mOffset;
	private float mZCoord;


	public bool holding = false;
	public Pointer pointer;


	private void Start() {
		pointer = VR08_GameManager.instance.pointer;
	}

	private void Update() {
		if (!holding) return;

		Transform pOrigin = pointer.GetOriginPosition();
		float distance = Vector3.Distance(transform.position, pOrigin.position);
		Vector3 nextPosition = pOrigin.position + (pOrigin.forward * distance);
		transform.position = new Vector3(nextPosition.x, nextPosition.y, transform.position.z);
	}

	public IEnumerable OnTriggerHold() {
		holding = true;
		yield return null;
	}

	public IEnumerable OnTriggerRelease() {
		holding = false;
		yield return null;
	}


	void OnMouseDown() {
		mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		mOffset = gameObject.transform.position - GetMouseWorldPos();
	}

	private Vector3 GetMouseWorldPos() {
		Vector3 mousePoint = Input.mousePosition;
		mousePoint.z = mZCoord;
		return Camera.main.ScreenToWorldPoint(mousePoint);
	}

	void OnMouseDrag() {
		transform.position = GetMouseWorldPos() + mOffset;
	}

	void OnCollisionEnter(Collision collision) {
		//Output the Collider's GameObject's name
		Debug.Log(collision.collider.name);
		if (collision.gameObject.name == "cube5") {
			collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
		}
		else if (
		  collision.gameObject.name == "cube2" ||
		  collision.gameObject.name == "cube3" ||
		  collision.gameObject.name == "cube4" ||
		  collision.gameObject.name == "cube1" ||
		  collision.gameObject.name == "cube6" ||
		  collision.gameObject.name == "cube7" ||
		  collision.gameObject.name == "cube8" ||
		  collision.gameObject.name == "cube9"

	  ) {
			collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
		}
	}

	void OnCollisionExit(Collision collision) {
		if (collision.gameObject.name == "cube5") {
			collision.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(236, 236, 236, 0); ;
		}
	}

	public IEnumerable OnPointerOver() {
		throw new System.NotImplementedException();
	}

	public IEnumerable OnPointerExit() {
		throw new System.NotImplementedException();
	}

	public IEnumerable OnTriggerPress() {
		throw new System.NotImplementedException();
	}


}
