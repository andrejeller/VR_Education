using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Wilberforce;

public class VR22_GameManager:MonoBehaviour {

	public VRController controler;
	public GameObject[] panel = new GameObject[4];
	public Colorblind l, r, c;

	private int type = 0;
	private float[] positions = { -0.56f, -0.37f, -0.20f, 0.00f, 0.20f, 0.37f, 0.56f };


	private void Start() {
		UpdatePanels();
		UpdateColorblind();
	}

	private void Update() {

		if (controler.SwipeDireita() || VRInput.sBotaoTesteDown()) {
			Add(-1); UpdatePanels(); UpdateColorblind();
		}

		if (controler.SwipeEsquerda() || VRInput.aBotaoTesteDown()) {
			Add(1); UpdatePanels(); UpdateColorblind();
		}
		
	}

	private void Add(int num) {
		type = type + num;
		if (type > 3) type = 3;
		if (type <= 0) type = 0;
	}

	private void UpdatePanels() {
		switch (type) {
			case 0:
				panel[0].transform.DOLocalMoveX(positions[3], 0.3f, false);
				panel[1].transform.DOLocalMoveX(positions[4], 0.3f, false);
				panel[2].transform.DOLocalMoveX(positions[5], 0.3f, false);
				panel[3].transform.DOLocalMoveX(positions[6], 0.3f, false);
				panel[0].transform.DOScale(1.0f, 0.3f);
				panel[1].transform.DOScale(0.8f, 0.3f);
				panel[2].transform.DOScale(0.8f, 0.3f);
				panel[3].transform.DOScale(0.8f, 0.3f);
				break;
			case 1:
				panel[0].transform.DOLocalMoveX(positions[2], 0.3f, false);
				panel[1].transform.DOLocalMoveX(positions[3], 0.3f, false);
				panel[2].transform.DOLocalMoveX(positions[4], 0.3f, false);
				panel[3].transform.DOLocalMoveX(positions[5], 0.3f, false);
				panel[0].transform.DOScale(0.8f, 0.3f);
				panel[1].transform.DOScale(1.0f, 0.3f);
				panel[2].transform.DOScale(0.8f, 0.3f);
				panel[3].transform.DOScale(0.8f, 0.3f);
				break;
			case 2:
				panel[0].transform.DOLocalMoveX(positions[1], 0.3f, false);
				panel[1].transform.DOLocalMoveX(positions[2], 0.3f, false);
				panel[2].transform.DOLocalMoveX(positions[3], 0.3f, false);
				panel[3].transform.DOLocalMoveX(positions[4], 0.3f, false);
				panel[0].transform.DOScale(0.8f, 0.3f);
				panel[1].transform.DOScale(0.8f, 0.3f);
				panel[2].transform.DOScale(1.0f, 0.3f);
				panel[3].transform.DOScale(0.8f, 0.3f);
				break;
			case 3:
				panel[0].transform.DOLocalMoveX(positions[0], 0.3f, false);
				panel[1].transform.DOLocalMoveX(positions[1], 0.3f, false);
				panel[2].transform.DOLocalMoveX(positions[2], 0.3f, false);
				panel[3].transform.DOLocalMoveX(positions[3], 0.3f, false);
				panel[0].transform.DOScale(0.8f, 0.3f);
				panel[1].transform.DOScale(0.8f, 0.3f);
				panel[2].transform.DOScale(0.8f, 0.3f);
				panel[3].transform.DOScale(1.0f, 0.3f);
				break;
		}
	}

	private void UpdateColorblind() {
		switch (type) {
			case 0:
				l.Type = 0;
				r.Type = 0;
				c.Type = 0;
				break;
			case 1:
				l.Type = 2;
				r.Type = 1;
				c.Type = 1;
				break;
			case 2:
				l.Type = 2;
				r.Type = 2;
				c.Type = 2;
				break;
			case 3:
				l.Type = 3;
				r.Type = 3;
				c.Type = 3;
				break;
		}
	}

}
