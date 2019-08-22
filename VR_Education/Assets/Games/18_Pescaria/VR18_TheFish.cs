using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class VR18_TheFish:MonoBehaviour {


	public PathCreator pathCreator;
	public EndOfPathInstruction endOfPathInstruction;
	public float speed = 25;
	float distanceTravelled;
	bool rotateNow = true;
	bool follow = false;
	bool snap = false;


	void OnPathChanged() {
		distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
	}

	public VR18_TheFish SetPathCreator(PathCreator pCreator) {
		pathCreator = pCreator;
		return this;
	}

	private void Start() {
		if (pathCreator != null) {
			// Subscribed to the pathUpdated event so that we're notified if the path changes during the game
			pathCreator.pathUpdated += OnPathChanged;
			distanceTravelled = transform.position.z;
		}
	}


	void Update() {



		if (VR18_GameManager.instance.inWater) {

			//COMECA IENUMERATOR PARA SEGURAR O SCRIPT - COUNTDWON para rand de novo

			//Porcentagem de chance de persegir 
			int rand = Random.Range(0, 4);
			if (rand == 0) follow = true;

			if (follow && !snap && Vector3.Distance(transform.position, VR18_GameManager.instance.pontaPos) > 3.0f) {
				transform.LookAt(VR18_GameManager.instance.pontaPos);
				transform.position += transform.forward * 0.3f;
			}
			if (Vector3.Distance(transform.position, VR18_GameManager.instance.pontaPos) < 1.0f && VRInput.aBotaoTesteDown()) {
				//if chegou perto da vara, gruda
				transform.parent = VR18_GameManager.instance.ponta.transform;
				snap = true;
			}
			if (VRInput.TriggerUp()) snap = false;


		} //ver y para impedir 
		else if (!follow && !snap && transform.position.y < 0) {
			if (pathCreator != null) {
				distanceTravelled += speed * Time.deltaTime;
				Vector3 pos = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
				Vector3 rot = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction).eulerAngles;

				transform.position = new Vector3(pos.x, pos.y - 0.8f, pos.z);
				transform.rotation = Quaternion.Euler(new Vector3(rot.x, rot.y, rot.z));
			}
		}


	}

	private IEnumerator YEAH() {

		yield return new WaitForSeconds(3.4f);




		yield return null;
	}

}
