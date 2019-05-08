using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VR01_GameManager : MonoBehaviour {

    public static VR01_GameManager instance;

    public TextMeshProUGUI txt_Question;
    public TextMeshProUGUI txt_Awnser0;
    public TextMeshProUGUI txt_Awnser1;
    public TextMeshProUGUI txt_Awnser2;
    public TextMeshProUGUI txt_Awnser3;

	private bool CanRespond = true;

    private int ActualCorrectAwnser = 0;
    private int ActualQuestion = 0;
	public VR01_AnswersPanels answersPanels;


    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start(){
		VR01_XMLManager.instance.LoadQuestions();
		UpdateQuestionsText(0);
	}

    private void UpdateQuestionsText(int questionNumber){
		ActualCorrectAwnser = VR01_XMLManager.instance.quest[questionNumber].correctAnswer;
		txt_Question.text = VR01_XMLManager.instance.quest[questionNumber].myQuestion;
		txt_Awnser0.text  = VR01_XMLManager.instance.quest[questionNumber].Answers[0].theAnswerText;
		txt_Awnser1.text  = VR01_XMLManager.instance.quest[questionNumber].Answers[1].theAnswerText;
		txt_Awnser2.text  = VR01_XMLManager.instance.quest[questionNumber].Answers[2].theAnswerText;
		txt_Awnser3.text  = VR01_XMLManager.instance.quest[questionNumber].Answers[3].theAnswerText;
	}


    public void AwnserButtonClicked(int id) {
		if (!CanRespond) return;
		CanRespond = false;
		if (id == ActualCorrectAwnser) {
			//Vivaa!
		}
		else {

		}
		answersPanels.Flash(ActualCorrectAwnser, id);
	}

	public void NextQuestion() {
		ActualQuestion++;
		UpdateQuestionsText(ActualQuestion);
		CanRespond = true;
	}

    //Translate A,B,C,D to 0,1,2,3
}
