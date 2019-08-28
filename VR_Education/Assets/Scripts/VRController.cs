using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRController:MonoBehaviour {


	public GameObject touch;
	private float begin, end;
	private bool comecou = false;
	private bool swpDireita, swpEsquerda, canSwipe = true;

	void Update() {

		float x = VRInput.Axes().x;
		float y = VRInput.Axes().y;

		if (x != 0.0f && y != 0.0f) {
			x += 1; y += 1;
			x = Mathf.Lerp(-0.045f, 0.045f, x / 2);
			//y = Mathf.Lerp(-0.045f, 0.045f, y / 2);
		}


		if (x != 0 && !comecou) {
			comecou = true;
			begin = x;
		}
		else if (x != 0 && comecou) {
			//comecou = false;
			end = x; //vai entrar 0
		}

		if (x == 0 && canSwipe) {
			comecou = false;
			if (begin > 0 && end < 0) {
				swpDireita = true; 
				StartCoroutine(endSwipe());
			}
			else if (begin < 0 && end > 0) {
				swpEsquerda = true; 
				StartCoroutine(endSwipe());
			}
		}

	}


	private IEnumerator endSwipe() {
		canSwipe = false;
		yield return new WaitForSeconds(0.3f);
		swpEsquerda = false;
		swpDireita = false;
		canSwipe = true;
		begin = 0;
		end = 0;

		yield return null;
	}

	public bool SwipeDireita() {
		if (swpDireita) return true;
		return false;
	}
	public bool SwipeEsquerda() {
		if (swpEsquerda) return true;
		return false;
	}

}
