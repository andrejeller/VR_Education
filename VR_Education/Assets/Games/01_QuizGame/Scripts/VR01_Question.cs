using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;


[System.Serializable]
public class VR01_Question {

    [XmlElement("question")]
    public List<VR01_Question> Questions = new List<VR01_Question>();

}

[System.Serializable]
public class VR01_QuestionToAsk {

    public bool answered; //Para nao repetir

    [XmlAttribute("number")]
    public int QuestionID;
    [XmlAttribute("value")]
    public string myQuestion;
    [XmlAttribute("about")]
    public string about;
    [XmlAttribute("correctAnswer")]
    public int correctAnswer;
    
    [XmlElement("answer")]
    public List<VR01_QuestionAnswer> Answers = new List<VR01_QuestionAnswer>();
}

[System.Serializable]
public class VR01_QuestionAnswer {
    [XmlAttribute("correctAnswer")]
    public int answerID;

    [XmlText]
    public string theAnswerText;
}