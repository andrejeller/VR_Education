using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR01_QuizGame: MonoBehaviour {

    [SerializeField]
    private int buttonID;
    [SerializeField]
    private GameObject buttonCircle; // 0.09 -> 0.16
    private float moveTime = 0.3f;
    private bool canBePressed = true;

    private void Start() {
        canBePressed = true;
        Vector3 newPosition = new Vector3(0, 0.16f, 0);
        buttonCircle.transform.localPosition = newPosition;
    }

    private void BeingPressed() {
        canBePressed = false;
        VR01_GameManager.instance.AwnserButtonClicked(buttonID);
        buttonCircle.transform.DOLocalMoveY(0.09f, 0.3f, false).OnComplete(() => {
            buttonCircle.transform.DOLocalMoveY(0.16f, 0.3f, false).OnComplete(() => canBePressed = true);
        });
    }

    private void OnCollisionEnter(Collision collision) {
        BeingPressed();
    }

#if UNITY_EDITOR
    private void OnMouseOver() {
        if (canBePressed) BeingPressed();
    }
#endif
}
