using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VR24_GameManager : MonoBehaviour {
	public static VR24_GameManager instance;
	private void Awake() {
		if (instance == null) instance = this;
		else Destroy(gameObject);
	}


	[Header("Canvas")]
	public TextMeshProUGUI MathQuestion;
	public Sprite on, off;
	public Image[] buttons = new Image[4];

	[Header("!Canvas")]
	public GameObject balloonPrefab;

	private List<VR24_Contas> contas = new List<VR24_Contas>();


	private void Start() {
		SetButtons(off);
		string[] res = {"6", "9", "7", "4", "2", "5", "3", "1" };
		contas.Add(new VR24_Contas("3 + 3 =", res));
		UpdateText(contas[0]._conta);
		//StartCoroutine(flashButtons());
	}



	private void CreateBalloons() {
		//rand quantidade
		//vao ser sempre 8 - primeiro item sempre é o certo
		
		//cria os baloes
		//rend de cor
		//numeros/respostas
		//solta os baloes

	}

	private void UpdateText(string text) {
		MathQuestion.text = text;
	}

	private IEnumerator flashButtons() {
		SetButtons(off);
		yield return new WaitForSeconds(0.3f);
		buttons[0].sprite = on;
		yield return new WaitForSeconds(0.5f);
		buttons[1].sprite = on;
		yield return new WaitForSeconds(0.5f);
		buttons[2].sprite = on;
		yield return new WaitForSeconds(0.5f);
		buttons[3].sprite = on;
		yield return new WaitForSeconds(0.5f);
		SetButtons(off);
		yield return new WaitForSeconds(0.2f);
		SetButtons(on);
		yield return new WaitForSeconds(0.2f);
		SetButtons(off);
		yield return new WaitForSeconds(0.2f);
		SetButtons(on);
		yield return new WaitForSeconds(0.2f);
		SetButtons(off);
		yield return new WaitForSeconds(0.2f);
		SetButtons(on);

		yield return null;
	}
	private void SetButtons(Sprite mode) {
		buttons[0].sprite = mode;
		buttons[1].sprite = mode;
		buttons[2].sprite = mode;
		buttons[3].sprite = mode;
	}

}
