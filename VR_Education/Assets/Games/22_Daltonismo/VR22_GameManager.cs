using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR22_GameManager:MonoBehaviour {

	public VRController controler;
	public GameObject[] panel = new GameObject[3];

	private float[] positions = { -0.37f, -0.20f, 0.00f, 0.20f, 0.37f };
	private int[] inPosition = { 1, 2, 3 };

	private void Update() {

		if (controler.SwipeDireita())
			MoveRight();

		if (controler.SwipeEsquerda())
			MoveLeft();

	}

	private void MoveRight() {
		for (int i = 0; i < inPosition.Length; i++) inPosition[i]++;
		// if pos>5 pos = 5;

		for (int i = 0; i < panel.Length; i++)
			panel[i].transform.DOLocalMoveX(positions[inPosition[i]], 0.3f, false);

	}

	private void MoveLeft() {
		for (int i = 0; i < inPosition.Length; i++) inPosition[i]--;

		for (int i = 0; i < panel.Length; i++)
			panel[i].transform.DOLocalMoveX(positions[inPosition[i]], 0.3f, false);
	}

}
