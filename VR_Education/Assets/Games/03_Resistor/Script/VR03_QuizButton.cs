using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Random = UnityEngine.Random;


[SelectionBase]
public class VR03_QuizButton: MonoBehaviour {

    [SerializeField]
    private int buttonID;
    [SerializeField]
    private GameObject buttonCircle; // 0.09 -> 0.16
    private float moveTime = 0.3f;
    private bool canBePressed = true;
    private int energy;
    private int lampenergy;
    public GameObject textObj0;
    public GameObject textObj1;
    private Text txt;
    public float yy;
    
    public GameObject cap1;
    public GameObject cap2;
    public GameObject cap3;
    public GameObject light;
    private VR03_Pin[] pinnedScript;

	[SerializeField]
	private GameObject explosionPrefab;
    public GameObject explosionPlace;

    private void Start()
    {
        txt = textObj0.GetComponent<Text>();
        lampenergy = Random.Range(500, 900);
        txt.text = ""+lampenergy;
        
        txt = textObj1.GetComponent<Text>();
        energy = Random.Range(1300, 2200);
        txt.text = ""+energy;
        
        canBePressed = true;
        yy = buttonCircle.gameObject.transform.localPosition.y;
        pinnedScript = new VR03_Pin[3];
        pinnedScript[0] = cap1.GetComponent<VR03_Pin>();
        pinnedScript[1] = cap2.GetComponent<VR03_Pin>();
        pinnedScript[2] = cap3.GetComponent<VR03_Pin>();
    }

    private void Update()
    {
        
    }

    private void BeingPressed() {
        canBePressed = false;
        int total = energy - pinnedScript[0].correctPin() - pinnedScript[1].correctPin() - pinnedScript[2].correctPin();
        if (total <=lampenergy+lampenergy*0.05 && total >=lampenergy-lampenergy*0.05)
        {
            light.gameObject.GetComponent<Light>().enabled = true;
        }
        else
        {
            GameObject a = Instantiate(explosionPrefab, explosionPlace.gameObject.transform.position, Quaternion.identity);
            Destroy(a.gameObject, 0.7f);
            buttonCircle.transform.DOLocalMoveY(yy-0.02f, 0.3f, false).OnComplete(() => {
                buttonCircle.transform.DOLocalMoveY(yy, 0.6f, false).OnComplete(() => canBePressed = true);
            });
        }

		

    }

	private void OnTriggerEnter(Collider other) {
		if (canBePressed && other.gameObject.tag == "Hand") BeingPressed();
	}

	private void OnCollisionEnter(Collision collision) {
    }

#if UNITY_EDITOR
    private void OnMouseOver() {
        if (canBePressed) BeingPressed();
    }
#endif
}
