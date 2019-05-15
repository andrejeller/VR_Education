using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[SelectionBase]
public class VR01_QuizButton: MonoBehaviour {

    [SerializeField]
    private int buttonID;
    [SerializeField]
    private GameObject buttonCircle; // 0.09 -> 0.16
    private float moveTime = 0.3f;
    private bool canBePressed = true;

	[SerializeField]
	private GameObject explosionPrefab;

    private void Start() {
        canBePressed = true;
        Vector3 newPosition = new Vector3(0, 0.16f, 0);
        buttonCircle.transform.localPosition = newPosition;
    }

    private void BeingPressed() {
        canBePressed = false;
		GameObject a = Instantiate(explosionPrefab, new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z - 0.06f), Quaternion.identity);
		Destroy(a.gameObject, 0.7f);


		VR01_GameManager.instance.AwnserButtonClicked(buttonID);
        buttonCircle.transform.DOLocalMoveY(0.09f, 0.3f, false).OnComplete(() => {
            buttonCircle.transform.DOLocalMoveY(0.16f, 0.6f, false).OnComplete(() => canBePressed = true);
        });

    }

	private void OnTriggerEnter(Collider other) {
		if (canBePressed) BeingPressed();
	}

	private void OnCollisionEnter(Collision collision) {
    }

#if UNITY_EDITOR
    private void OnMouseOver() {
        if (canBePressed) BeingPressed();
    }
#endif
}
