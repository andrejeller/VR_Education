using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using DG.Tweening;

public class VR06_Hemacia:MonoBehaviour {

	public PathCreator pathCreator;
	public EndOfPathInstruction endOfPathInstruction;
	public float speed = 25;
	float distanceTravelled;
	bool rotateNow = true;
	Vector3 plusXZ;

	void Start() {
		if (pathCreator != null) {
			// Subscribed to the pathUpdated event so that we're notified if the path changes during the game
			pathCreator.pathUpdated += OnPathChanged;
			distanceTravelled = transform.position.z;
			plusXZ = new Vector3(Random.Range(-1.5f, 1.5f), 0, Random.Range(-15, 15));
		}
	}

	void Update() {
		if (pathCreator != null) {
			distanceTravelled += speed * Time.deltaTime;
			Vector3 pos = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);


			transform.position = new Vector3(pos.x + plusXZ.x, transform.position.y, pos.z + plusXZ.z);

			if (rotateNow) {
				rotateNow = false;
				transform.DORotate(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)), 3.0f, RotateMode.LocalAxisAdd).OnComplete(()=> { rotateNow = true; });
			}

			//transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
		}
	}

	// If the path changes during the game, update the distance travelled so that the follower's position on the new path
	// is as close as possible to its position on the old path
	void OnPathChanged() {
		distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
	}

}
