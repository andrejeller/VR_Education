using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

public class VR09_XMLManager : MonoBehaviour {

	public static VR09_XMLManager instance;

	private void Awake() {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	}

	public List<VR09_WordToShow> word { get { return XMLWords.words; } }
	public VR09_Palavra XMLWords = new VR09_Palavra();
	private string fileName = "VR09_Palavras";

	public void LoadXML() {
		Debug.Log("[AJS] LOADING AND IMPORTING...");
		XmlSerializer serializer = new XmlSerializer(typeof(VR09_Palavra));

		var xmlFile = Resources.Load<TextAsset>(fileName);

		if (xmlFile) {

			XMLWords = serializer.Deserialize(GenerateStreamFromString(xmlFile.text)) as VR09_Palavra;
			Debug.Log("[AJS] IMPORTED WITH SUCCESS. :)");

		}
		else {
			Debug.LogError("[AJS] IMPORTING FAILED ... File doesen't exist. :/");
		}

	}

	public Stream GenerateStreamFromString(string s) {
		return new MemoryStream(Encoding.UTF8.GetBytes(s));
	}

}
