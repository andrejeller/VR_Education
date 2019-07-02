using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

[System.Serializable]
public class VR09_Palavra  {

	[XmlElement("Word")]
	public List<VR09_WordToShow> words = new List<VR09_WordToShow>();
}

[System.Serializable]
public class VR09_WordToShow {

	[XmlText]
	public string theWord;
}