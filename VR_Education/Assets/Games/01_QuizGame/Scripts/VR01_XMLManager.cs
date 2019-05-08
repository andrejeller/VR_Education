using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

public class VR01_XMLManager:MonoBehaviour {

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

#region Loading Questions
    public void LoadQuestions() {
        XmlSerializer serializer = new XmlSerializer(typeof(VR01_Question));
        string bookPath = Path.Combine(Application.streamingAssetsPath, "VR01_Perguntas.xml");

//#if UNITY_ANDROID
        Debug.Log("SYS: Entrando em Android Path");
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "VR01_Perguntas.xml");

        StartCoroutine(WaitinForLoad(filePath));



//#endif
#if UNITY_EDITOR

        if (File.Exists(bookPath)) {
            FileStream stream = new FileStream(bookPath, FileMode.Open);
            questions = serializer.Deserialize(stream) as VR01_Question;
            stream.Close();
        } else {
            Debug.LogError("This book does not Exist");
        }
#endif
    }


    IEnumerator WaitinForLoad(string filePath) {
        string result = "";
        XmlSerializer serializer = new XmlSerializer(typeof(VR01_Question));

        if (filePath.Contains("://")) {
            WWW www = new WWW(filePath);
            yield return www;
            result = www.text;

            questions = serializer.Deserialize(GenerateStreamFromString(result)) as VR01_Question;
            Debug.Log("SYS:  1- " + result);

        } else {
            result = System.IO.File.ReadAllText(filePath);
            questions = serializer.Deserialize(GenerateStreamFromString(result)) as VR01_Question;
            Debug.Log("SYS:  2- " + result);
        }
    }

    public Stream GenerateStreamFromString(string s) {
        return new MemoryStream(Encoding.UTF8.GetBytes(s));
    }
#endregion

}
