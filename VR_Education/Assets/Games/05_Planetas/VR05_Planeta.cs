using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[SelectionBase]
public class VR05_Planeta:MonoBehaviour, IInteractable {

	public bool isTheSun;
	public bool onCreation;

	private Vector3 vel;
	public VR05_Planeta outro;
	public float mass;
	public Vector3 pos { get { return transform.position; } set { transform.position = value; } }
	float Fa = 0; //Força de Atração
	float g = 0.1f;
	private float dee;
	public GameObject selectSphere;

	public bool holding = false;

	void Start() {
		mass = transform.localScale.x;
		vel.Set(0.005f, 0.0f, 0.001f);
		selectSphere.SetActive(false);
	}

	public void Initialize(float size) {
		transform.localScale = new Vector3(size, size, size);
		mass = transform.localScale.x;
		vel.Set(0.005f, 0.0f, 0.001f);
		selectSphere.SetActive(false);
	}

	void Update() {

		if (holding) {

			Vector3 force = Vector3.zero;
			Vector3 acceleration = Vector3.zero;

			pos += (vel + acceleration / 2.0f) * 5;
			vel += acceleration;


			Transform pOrigin = VR05_GameManager.instance.pointer.GetOriginPosition();
			float distance = Vector3.Distance(transform.position, pOrigin.position);
			transform.position = pOrigin.position + (pOrigin.forward * distance);
		}
		else {

			if (isTheSun) return;

			for (int i = 0; i < VR05_GameManager.instance.ActivePlanets.Count; i++) {
				outro = VR05_GameManager.instance.ActivePlanets[i];
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

		if (onCreation) {
			Transform pOrigin = VR05_GameManager.instance.pointer.GetOriginPosition();
			Vector3 goTo = pOrigin.forward * 5;
			transform.DOMove(goTo, 1.3f, false);
			yield return new WaitForSeconds(1.3f);
			isTheSun = false;
			onCreation = false;
		}

		DEBUG.dbg.Updt("On Release");
		yield return null;
	}

	public IEnumerable OnPointerExit() {
		selectSphere.SetActive(false);
		yield return null;
	}
	public IEnumerable OnPointerOver() {
		selectSphere.SetActive(true);
		yield return null;
	}
	public IEnumerable OnTriggerPress() {
		DEBUG.dbg.Updt("PRESS");
		holding = true;
		yield return null;
	}

}
