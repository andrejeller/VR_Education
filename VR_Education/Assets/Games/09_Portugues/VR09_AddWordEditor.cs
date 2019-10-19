using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;

[CustomEditor(typeof(VR09_AddWord))]
public class VR09_AddWordEditor:Editor {

	string newWord;

	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		VR09_AddWord myScript = (VR09_AddWord)target;

		GUILayout.Label("ADD A WORD TO XML FILE", new GUIStyle{ fontSize = 20, alignment = TextAnchor.MiddleCenter }, GUILayout.ExpandWidth(true));

		GUILayout.Space(10);

		newWord = GUILayout.TextField(newWord, GUILayout.ExpandWidth(true));
		int size = (newWord.Length == 0) ? 0 : newWord.Length;


		GUILayout.Label("This word has " + size + " characters", new GUIStyle { fontSize = 10 });


		GUILayout.Space(5);

		if (GUILayout.Button("Add to XML")) {
			//myScript.AddWord(newWord, newWord.Length);
		}
	}
}
#endif