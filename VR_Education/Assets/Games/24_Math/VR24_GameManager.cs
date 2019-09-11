using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VR24_GameManager : MonoBehaviour {


	[Header("Canvas")]
	public TextMeshProUGUI MathQuestion;
	public Sprite on, off;
	public Image[] buttons = new Image[4];

	[Header("!Canvas")]
	public GameObject balloonPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
