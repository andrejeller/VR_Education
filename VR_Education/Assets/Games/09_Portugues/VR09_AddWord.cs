using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR09_AddWord : MonoBehaviour {

	public VR09_XMLManager manager;

	public void AddWord(string text, int length) {

		manager.LoadWords();

		VR09_WordToShow nova = new VR09_WordToShow();
		nova.theWord = text;

		manager.XMLWords.words.Add(nova);
		manager.Save();
	}

}
