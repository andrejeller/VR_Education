using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class VR05_Planeta:MonoBehaviour, IInteractable {

	public bool canMove;

	private Vector3 vel;
	public VR05_Planeta outro;
	public float mass;
	public Vector3 pos { get { return transform.position; } set { transform.position = value; } }
	float Fa = 0; //Força de Atração
	float g = 0.1f;
	private float dee;

	public bool holding = false;

	void Start() {
		mass = transform.localScale.x;
		vel.Set(0.005f, 0.0f, 0.001f);
	}

	void Update() {

		if (holding) {

			Transform pOrigin = VR05_GameManager.instance.pointer.GetOriginPosition();
			float distance = Vector3.Distance(transform.position, pOrigin.position);
			transform.position = pOrigin.position + (pOrigin.forward * distance);
		}
		else {

			if (!canMove) return;

			for (int i = 0; i < VR05_GameManager.instance.planetas.Length; i++) {
				outro = VR05_GameManager.instance.planetas[i];
				if (outro == this) continue;


				Vector3 direction = outro.pos - pos;
				float d = Mathf.Sqrt((Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2)));


				//if (d < 330.0f) d = 330.0f;
				//if (d > 700.0f) d = 700.0f;
				d = 40;

				Fa = (mass * outro.mass * g) / Mathf.Pow(d, 2);


				Vector3 force = direction.normalized * Fa;
				Vector3 acceleration = force / mass;

				pos += (vel + acceleration / 2.0f) * 5;
				vel += acceleration;

			}
		}


	}

	public IEnumerable OnTriggerHold() {
		DEBUG.dbg.Updt("Hold");
		holding = true;
		yield return null;
	}

	public IEnumerable OnTriggerRelease() {
		holding = false;
		DEBUG.dbg.Updt("On Release");
		yield return null;
	}

	public IEnumerable OnPointerExit() {
		throw new System.NotImplementedException();
	}
	public IEnumerable OnPointerOver() {
		throw new System.NotImplementedException();
	}
	public IEnumerable OnTriggerPress() {
		throw new System.NotImplementedException();
	}

}
