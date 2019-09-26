using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR09_GameManager:MonoBehaviour {

	public static VR09_GameManager instance;
	private void Awake() {
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}


	public Pointer pointer;
	public VR09_CharPlace[] places;
	public VR09_CharBlock[] blocks;
	public GameObject particle;
	public Transform board;

	public AudioClip win;
	public AudioSource sound;


	private Vector3[] blockPositions = { new Vector3(19, -1.4f, 66), new Vector3(19, -1.4f, 48), new Vector3(19, -1.4f, 29), new Vector3(19, -1.4f, 11), new Vector3(19, -1.4f, -7.5f),
										 new Vector3(0, -1.4f, 66),  new Vector3(0, -1.4f, 48),  new Vector3(0, -1.4f, 29),  new Vector3(0, -1.4f, 11),  new Vector3(0, -1.4f, -7.5f) };

	private int[] randomPosition = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

	private string actualWord;
	private int[] jafoi;
	private int corretos = 0;

	private IEnumerator Start() {
		pointer.Distance = 2700.0f;

		yield return new WaitForSeconds(0.5f);
		VR09_XMLManager.instance.LoadXML();
		GetNewWord();
	}

	public void CardIn(bool state) {
		if (state) corretos++;
		else corretos--;

		if (corretos >= actualWord.Length) {
			StartCoroutine(Finished());
		}

	}

	public void GetNewWord() {
		int a = Random.Range(0, VR09_XMLManager.instance.XMLWords.words.Count);
		actualWord = VR09_XMLManager.instance.XMLWords.words[a].theWord;
		corretos = 0;
		UpdateBlocks();
	}

	private void UpdateBlocks() {

		ChangePosition();

		for (int i = 0; i < actualWord.Length; i++) {
			blocks[i].gameObject.SetActive(true);
			places[i].gameObject.SetActive(true);
			places[i].ResetPlace();
			blocks[i].texto = actualWord[i].ToString();
			places[i].myChar = actualWord[i];
		}
		for (int i = actualWord.Length; i < 10; i++) {
			blocks[i].gameObject.SetActive(false);
			places[i].gameObject.SetActive(false);
		}

	}

	private void ChangePosition() {
		//Inicia com 0 para saber quais ja foram alterados
		for (int i = 0; i < 10; i++) {
			randomPosition[i] = 0;
		}


		for (int i = 0; i < 10; i++) {
			int newNumber = Random.Range(1, 10);
			bool jaFoi = false;

			for (int j = 0; j <= i; j++) {
				if (jaFoi) {
					jaFoi = false;
				}
				if (newNumber == randomPosition[j]) {
					newNumber = Random.Range(1, 11);
					j = 0;
					jaFoi = true;
				}
			}

			randomPosition[i] = newNumber;
		}

		for (int i = 0; i < 10; i++)
			blocks[i].transform.localPosition = blockPositions[randomPosition[i] - 1];

	}

	private IEnumerator Finished() {

		yield return new WaitUntil(() => !pointer.IsHodingSomething || !Input.GetMouseButton(0));
		GameObject a = Instantiate(particle, board);
		sound.PlayOneShot(win, 1);

		yield return new WaitForSeconds(2.5f);
		GetNewWord();
	}

}
