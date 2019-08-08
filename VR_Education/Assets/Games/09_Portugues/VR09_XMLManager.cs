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

	//Lista de Itens
	public VR09_Palavra XMLWords;


	public void Save() {

		XmlSerializer serializer = new XmlSerializer(typeof(VR09_Palavra));
		FileStream file = new FileStream(Application.streamingAssetsPath + "/../VR09_Palavras.xml", FileMode.OpenOrCreate);
		serializer.Serialize(file, XMLWords);
		
		file.Close();
		Debug.Log("SaveComplete " + XMLWords.words[XMLWords.words.Count - 1].theWord);
		//Debug.Log("../" + Application.persistentDataPath);
	}




	#region Loading Words
	public void LoadWords() {
		XmlSerializer serializer = new XmlSerializer(typeof(VR09_Palavra));
		string path = Path.Combine(Application.streamingAssetsPath, "../VR09_Palavras.xml");

		Debug.Log("SYS: Entrando em Android Path");
		StartCoroutine(WaitinForLoad(path));

#if UNITY_EDITOR

		if (File.Exists(path)) {
			FileStream stream = new FileStream(path, FileMode.Open);
			XMLWords = serializer.Deserialize(stream) as VR09_Palavra;
			stream.Close();
			//VR01_GameManager.instance.DisplayFirstQuestion();
		}
		else {
			Debug.LogError("This book does not Exist");
			//VR01_GameManager.instance.DisplayFirstQuestion();
		}
#endif
	}


	IEnumerator WaitinForLoad(string filePath) {
		string result = "";
		XmlSerializer serializer = new XmlSerializer(typeof(VR09_Palavra));

		if (filePath.Contains("://")) {

			WWW www = new WWW(filePath);
			yield return www;
			result = www.text;
			XMLWords = serializer.Deserialize(GenerateStreamFromString(result)) as VR09_Palavra;

			Debug.Log("SYS:  1- " + result);
			//VR01_GameManager.instance.DisplayFirstQuestion();
		}
		else {

			result = System.IO.File.ReadAllText(filePath);
			XMLWords = serializer.Deserialize(GenerateStreamFromString(result)) as VR09_Palavra;
			Debug.Log("SYS:  2- " + result);
			//VR01_GameManager.instance.DisplayFirstQuestion();
		}
	}

	public Stream GenerateStreamFromString(string s) {
		return new MemoryStream(Encoding.UTF8.GetBytes(s));
	}
	#endregion

}
