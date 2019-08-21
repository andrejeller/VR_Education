using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class VR18_Shark : MonoBehaviour {


	public PathCreator pathCreator;
	public EndOfPathInstruction endOfPathInstruction;
	public float speed = 25;
	float distanceTravelled;
	bool rotateNow = true;

	void Start() {
		if (pathCreator != null) {
			// Subscribed to the pathUpdated event so that we're notified if the path changes during the game
			pathCreator.pathUpdated += OnPathChanged;
			distanceTravelled = transform.position.z;
		}
	}

	void Update() {
		if (pathCreator != null) {
			distanceTravelled += speed * Time.deltaTime;
			Vector3 pos = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
			Vector3 rot = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction).eulerAngles;

			transform.position = new Vector3(pos.x, pos.y, pos.z);
			transform.rotation = Quaternion.Euler(new Vector3(rot.x, rot.y, rot.y));
		}
	}

	// If the path changes during the game, update the distance travelled so that the follower's position on the new path
	// is as close as possible to its position on the old path
	void OnPathChanged() {
		distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
	}
}
