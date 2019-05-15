using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

public class VR01_XMLManager: MonoBehaviour {

	public static VR01_XMLManager instance;

	private void Awake() {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	}

	//Lista de Itens
	private VR01_Question questions;
	public List<VR01_QuestionToAsk> quest {
		get { return questions.Questions; }
	}

	private void Start() {
		//VR01_GameManager.instance.UsingPanelAsDebug("XML Manager Starts");
		//DEBUG.dbg.Update("Init XML manager");
	}

	#region Loading Questions
	public void LoadQuestions() {
		XmlSerializer serializer = new XmlSerializer(typeof(VR01_Question));
        string path = Path.Combine(Application.streamingAssetsPath, "VR01_Perguntas.xml");
		//string path = "jar:file://" + Application.dataPath + "!/assets/VR01_Perguntas.xml";

		//#if UNITY_ANDROID
		Debug.Log("SYS: Entrando em Android Path");
		//DEBUG.dbg.Update("Entrando em android path");
		// string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "VR01_Perguntas.xml");
		//string path = "jar:file://" + Application.dataPath + "!/assets/";

		StartCoroutine(WaitinForLoad(path));



//#endif
#if UNITY_EDITOR

        if (File.Exists(path)) {
            FileStream stream = new FileStream(path, FileMode.Open);
            questions = serializer.Deserialize(stream) as VR01_Question;
            stream.Close();
			VR01_GameManager.instance.DisplayFirstQuestion();
		} else {
            Debug.LogError("This book does not Exist");
			VR01_GameManager.instance.DisplayFirstQuestion();
		}
#endif
    }


    IEnumerator WaitinForLoad(string filePath) {
        string result = "";
        XmlSerializer serializer = new XmlSerializer(typeof(VR01_Question));
		//VR01_GameManager.instance.UsingPanelAsDebug("searching");
		if (filePath.Contains("://")) {
			
			WWW www = new WWW(filePath);
            yield return www;
            result = www.text;
			questions = serializer.Deserialize(GenerateStreamFromString(result)) as VR01_Question;
			//VR01_GameManager.instance.UsingPanelAsDebug(result);
            Debug.Log("SYS:  1- " + result);
			//DEBUG.dbg.Update(result);
			VR01_GameManager.instance.DisplayFirstQuestion();
		} else {

			result = System.IO.File.ReadAllText(filePath);
			questions = serializer.Deserialize(GenerateStreamFromString(result)) as VR01_Question;
            Debug.Log("SYS:  2- " + result);
			//DEBUG.dbg.Update(result);
			VR01_GameManager.instance.DisplayFirstQuestion();
		}
    }

    public Stream GenerateStreamFromString(string s) {
        return new MemoryStream(Encoding.UTF8.GetBytes(s));
    }
#endregion

}
