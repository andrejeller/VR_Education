using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class VR18_TheFish:MonoBehaviour {


	public PathCreator pathCreator;
	public EndOfPathInstruction endOfPathInstruction;
	public float speed = 25;
	float distanceTravelled;

	bool follow = false, fisgou = false, soltou = false;

	private float lastTime;


	void OnPathChanged() {
		distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
	}
	public VR18_TheFish SetPathCreator(PathCreator pCreator) {
		pathCreator = pCreator;
		pathCreator.pathUpdated += OnPathChanged;
		distanceTravelled = transform.position.z;
		return this;
	}
	private void Start() {
		if (pathCreator != null) {
			// Subscribed to the pathUpdated event so that we're notified if the path changes during the game
			pathCreator.pathUpdated += OnPathChanged;
			distanceTravelled = transform.position.z;
		}
		lastTime = Time.time;
	}


	void Update() {


		if (fisgou && !soltou) {
			if (VRInput.TriggerDown()) {
				//fisgou = false;
				soltou = true;
				VR18_GameManager.instance.theresAFish = false;
			}

			return;
		}
		else if (fisgou && soltou) {
			//gravidade
			transform.parent = null;
			GetComponent<Rigidbody>().useGravity = true;
		}





		if (VR18_GameManager.instance.inWater) {

			//cooldown do rand
			if (Time.time - lastTime > 4.0f) {
				lastTime = Time.time;

				int rand = Random.Range(0, 4);
				if (rand == 0) follow = true;
			}

			//minha vez de seguir?
			if (distance() > 0.5f && distance() < 3.0f) {
				transform.LookAt(VR18_GameManager.instance.pontaPos);
				if (follow && !fisgou) {
					transform.position += transform.forward * 0.03f;
				}
			}

			//if esta perto da vara e foi apertado o botao, gruda
			if (distance() < 0.6f && VRInput.TriggerDown() && !VR18_GameManager.instance.theresAFish) {
				transform.parent = VR18_GameManager.instance.ponta.transform;
				fisgou = true; soltou = false;
				GetComponent<CharacterController>().enabled = false;

				VR18_GameManager.instance.theresAFish = true;
			}


		} //ver y para impedir 

		/*else if*/
		if (!follow && !fisgou && transform.position.y < 0 && pathCreator != null && distance() >= 3.0f) {

			distanceTravelled += speed * Time.deltaTime;
			Vector3 pos = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
			Vector3 rot = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction).eulerAngles;

			transform.position = new Vector3(pos.x, pos.y - 0.8f, pos.z);
			transform.rotation = Quaternion.Euler(new Vector3(rot.x, rot.y, rot.z));

		}



	}

	private void OnCollisionExit(Collision collision) {
		if (collision.gameObject.tag == "Ground" && GetComponent<Rigidbody>().useGravity)
			Destroy(gameObject);
	}

	private float distance() {
		return Vector3.Distance(transform.position, VR18_GameManager.instance.pontaPos);
	}

}
