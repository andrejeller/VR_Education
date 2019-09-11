using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

public class VR01_GameManager:MonoBehaviour {

	public static VR01_GameManager instance;
	private void Awake() {
		if (instance == null) instance = this;
		else Destroy(gameObject);
	}

	public TextMeshProUGUI txt_Question;
	public TextMeshProUGUI txt_Awnser0;
	public TextMeshProUGUI txt_Awnser1;
	public TextMeshProUGUI txt_Awnser2;
	public TextMeshProUGUI txt_Awnser3;

	private bool CanRespond = true;
	public bool loading = true;

	private int ActualCorrectAwnser = 0;
	private int ActualQuestion = 0;
	public VR01_AnswersPanels answersPanels;

	private IEnumerator Start() {
		//DEBUG.dbg.Update("Init Game manager");
		yield return new WaitForSeconds(0.5f);
		//VR01_XMLManager.instance.LoadQuestions();
		LoadXML();
		yield return new WaitForSeconds(0.8f);
		DisplayFirstQuestion();
	}

	private void UpdateQuestionsText(int questionNumber) {
		ActualCorrectAwnser = QUEST[questionNumber].correctAnswer;
		txt_Question.text = QUEST[questionNumber].myQuestion;
		txt_Awnser0.text = QUEST[questionNumber].Answers[0].theAnswerText;
		txt_Awnser1.text = QUEST[questionNumber].Answers[1].theAnswerText;
		txt_Awnser2.text = QUEST[questionNumber].Answers[2].theAnswerText;
		txt_Awnser3.text = QUEST[questionNumber].Answers[3].theAnswerText;

	}

	public void AwnserButtonClicked(int id) {
		if (!CanRespond) return;
		CanRespond = false;

		answersPanels.Flash(ActualCorrectAwnser, id);
	}

	public void DisplayFirstQuestion() {
		UpdateQuestionsText(0);
	}

	public void NextQuestion() {
		ActualQuestion++;

		if (ActualQuestion >= QUEST.Count) ActualQuestion = 0;

		UpdateQuestionsText(ActualQuestion);
		CanRespond = true;
	}

	//Translate A,B,C,D to 0,1,2,3


	public List<VR01_QuestionToAsk> QUEST { get { return questions.Questions; } set { questions.Questions = value; } }
	public VR01_Question questions = new VR01_Question();
	private string fileName = "VR01_Perguntas";

	public void LoadXML() {
		Debug.Log("[AJS] LOADING AND IMPORTING...");
		XmlSerializer serializer = new XmlSerializer(typeof(VR01_Question));

		var xmlFile = Resources.Load<TextAsset>(fileName);

		if (xmlFile) {

			questions = serializer.Deserialize(GenerateStreamFromString(xmlFile.text)) as VR01_Question;
			Debug.Log("[AJS] IMPORTED WITH SUCCESS. :)");

		}
		else {
			Debug.LogError("[AJS] IMPORTING FAILED ... File doesen't exist. :/");
		}

	}

	public static Stream GenerateStreamFromString(string s) {
		return new MemoryStream(Encoding.UTF8.GetBytes(s));
	}
	
}
