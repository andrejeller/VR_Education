using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VR24_Balloon : MonoBehaviour {

	public TextMeshProUGUI number;
	public Renderer myMaterial;
	public GameObject explosion;

	private string myNumber;
	private Color myColor;

	public void Init(string withNumber, Color withColor) {
		myNumber = withNumber;
		myColor = withColor;
		number.text = withNumber.ToString();
		myMaterial.material.color = withColor;
	}

	public void BUUM() {
		GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
		exp.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = myColor;
		gameObject.SetActive(false);
		Destroy(exp, 0.6f);
		Destroy(gameObject, 0.7f);
	}

	private void Update() {
		if (VR24_GameManager.instance.waitFlash) return;
		transform.position += Vector3.up * 3 * Time.deltaTime;
		if (transform.position.y >= 11) {
			BUUM();
			VR24_GameManager.instance.ExplodiuBalao("");
		}
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Virus") {
			Destroy(collision.gameObject);

			VR24_GameManager.instance.RemoveBalllon(gameObject);
			VR24_GameManager.instance.ExplodiuBalao(myNumber);
			BUUM();
			//explodir
		}
	}

}
