using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class VR24_GameManager:MonoBehaviour {
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
	public GameObject ballPrefab;
	public Transform spawnPoint;

	private List<VR24_Contas> contas = new List<VR24_Contas>();
	private List<GameObject> ballons = new List<GameObject>();
	private Color[] colors = { Color.gray, Color.green, Color.red, Color.yellow, Color.blue, Color.cyan, Color.magenta, Color.white };
	private int inQuestion = 0;
	public bool waitFlash = true;

	private void Start() {
		Math();
		inQuestion = 0;
		SetButtons(off);
		UpdateText(contas[0]._conta);
		CreateBalloons();
		StartCoroutine(flashButtons());
	}

	private void Update() {
		if (VRInput.TriggerDown() || VRInput.aBotaoTesteDown()) {
			GameObject a = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
			a.GetComponent<Rigidbody>().AddForce((spawnPoint.forward) * 18.5f, ForceMode.Impulse);
			a.transform.DOScale(0.6f, 1.3f);
		}
	}



	private void CreateBalloons() {
		//rand quantidade
		//vao ser sempre 8 - primeiro item sempre é o certo
		//cria os baloes
		//rand de cor
		//numeros/respostas

		for (int i = 0; i < 8; i++) {
			Vector3 spawnPosition = new Vector3(Random.Range(-8.0f, 8.0f), -2.0f, Random.Range(3.0f, 8.0f));
			GameObject newB = Instantiate(balloonPrefab, spawnPosition, Quaternion.identity);
			newB.GetComponent<VR24_Balloon>().Init(contas[inQuestion]._resultado[i], colors[Random.Range(0, 7)]);
			ballons.Add(newB);
		}




		//solta os baloes

		//espera a resposta ou eles serem destruidos

	}

	private void UpdateText(string text) {
		MathQuestion.text = text;
	}
	private void Math() {
		contas.Add(new VR24_Contas("3 + 3 =", new string[] { "6", "9", "7", "4", "2", "5", "3", "1" }));
		contas.Add(new VR24_Contas("12,48 + 19 =", new string[] { "31,48", "32,48", "30,48", "20,", "-6,52", "7,5", "31,5", "30,5" }));
		contas.Add(new VR24_Contas("200 x 0,3 =", new string[] { "60", "62", "600", ".", ".", ".", ".", "." }));
		contas.Add(new VR24_Contas("21 / 3 =", new string[] { "7", "14", "13,5", "17,3", "7,2", "5", "6", "9" }));
		contas.Add(new VR24_Contas("1² =", new string[] { "1", "2", "1,5", "0", "3", "12", "0.5", "7" }));
		contas.Add(new VR24_Contas("10³ =", new string[] { "1000", "3000", "30", "3", "100", "103", "310", "313" }));
		//contas.Add(new VR24_Contas("0 + 0 =", new string[] { ".", ".", ".", ".", ".", ".", ".", "." }));
	}

	public void ExplodiuBalao(string ballonValue) {

		//explode todos os baloes restantes
		for (int i = 0; i < ballons.Count; i++)
			ballons[i].GetComponent<VR24_Balloon>().BUUM();

		//confere se acertou e feedback resultado
		if (ballonValue == contas[inQuestion]._resultado[0]) {
			StartCoroutine(flashButtonsColor(Color.green));
		}
		else {
			StartCoroutine(flashButtonsColor(Color.red));
		}

		//limpa a lista
		ballons.Clear();

		//pergunta>max, perg = 0
		//nova pergunta
		inQuestion++;
		if (inQuestion >= contas.Count) inQuestion = 0;
		UpdateText(contas[inQuestion]._conta);

		//novos baloes
		CreateBalloons();
	}

	private IEnumerator flashButtons() {
		waitFlash = true;
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
		waitFlash = false;
		yield return null;
	}
	private IEnumerator flashButtonsColor(Color color) {
		waitFlash = true;
		buttons[0].color = color;
		buttons[1].color = color;
		buttons[2].color = color;
		buttons[3].color = color;

		buttons[0].color = new Color(color.r, color.g, color.b, 0.2f);
		buttons[1].color = new Color(color.r, color.g, color.b, 1.0f);
		buttons[2].color = new Color(color.r, color.g, color.b, 0.2f);
		buttons[3].color = new Color(color.r, color.g, color.b, 1.0f);
		yield return new WaitForSeconds(0.5f);
		buttons[0].color = new Color(color.r, color.g, color.b, 1.0f);
		buttons[1].color = new Color(color.r, color.g, color.b, 0.2f);
		buttons[2].color = new Color(color.r, color.g, color.b, 1.0f);
		buttons[3].color = new Color(color.r, color.g, color.b, 0.2f);
		yield return new WaitForSeconds(0.5f);
		buttons[0].color = new Color(color.r, color.g, color.b, 0.2f);
		buttons[1].color = new Color(color.r, color.g, color.b, 1.0f);
		buttons[2].color = new Color(color.r, color.g, color.b, 0.2f);
		buttons[3].color = new Color(color.r, color.g, color.b, 1.0f);
		yield return new WaitForSeconds(0.5f);
		buttons[0].color = new Color(color.r, color.g, color.b, 1.0f);
		buttons[1].color = new Color(color.r, color.g, color.b, 0.2f);
		buttons[2].color = new Color(color.r, color.g, color.b, 1.0f);
		buttons[3].color = new Color(color.r, color.g, color.b, 0.2f);
		yield return new WaitForSeconds(0.5f);
		buttons[0].color = new Color(color.r, color.g, color.b, 0.2f);
		buttons[1].color = new Color(color.r, color.g, color.b, 1.0f);
		buttons[2].color = new Color(color.r, color.g, color.b, 0.2f);
		buttons[3].color = new Color(color.r, color.g, color.b, 1.0f);
		yield return new WaitForSeconds(0.5f);
		buttons[0].color = new Color(color.r, color.g, color.b, 1.0f);
		buttons[1].color = new Color(color.r, color.g, color.b, 0.2f);
		buttons[2].color = new Color(color.r, color.g, color.b, 1.0f);
		buttons[3].color = new Color(color.r, color.g, color.b, 0.2f);
		yield return new WaitForSeconds(0.5f);

		buttons[0].color = Color.white;
		buttons[1].color = Color.white;
		buttons[2].color = Color.white;
		buttons[3].color = Color.white;

		waitFlash = false;
		yield return null;
	}
	private void SetButtons(Sprite mode) {
		buttons[0].sprite = mode;
		buttons[1].sprite = mode;
		buttons[2].sprite = mode;
		buttons[3].sprite = mode;
	}
	public void RemoveBalllon(GameObject b) {
		ballons.Remove(b);
	}
}
