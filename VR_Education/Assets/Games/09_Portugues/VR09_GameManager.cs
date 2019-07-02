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


	private string actualWord;
	private int[] jafoi;

	private IEnumerator Start() {
		//DEBUG.dbg.Update("Init Game manager");
		yield return new WaitForSeconds(0.5f);
		VR09_XMLManager.instance.LoadWords();
		GetNewWord();
		UpdateOnGame();
	}



	public void GetNewWord() {
		int a = Random.Range(0, VR09_XMLManager.instance.XMLWords.words.Count);
		actualWord = VR09_XMLManager.instance.XMLWords.words[a].theWord;
		UpdateOnGame();
	}


	private void UpdateOnGame() {
		for (int i = 0; i < actualWord.Length; i++) {
			blocks[i].gameObject.SetActive(true);
			places[i].gameObject.SetActive(true);
			blocks[i].texto = actualWord[i].ToString();
			places[i].myChar = actualWord[i];
		}
		for (int i = actualWord.Length; i < 10; i++) {
			blocks[i].gameObject.SetActive(false);
			places[i].gameObject.SetActive(false);
		}


	}


}
