using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class VR01_AnswersPanels:MonoBehaviour {

	public Image[] panels = new Image[4];
	private Color RColor = new Color(255, 0, 0, 0.33f);
	private Color GColor = new Color(0, 255, 0, 0.33f);
	private Color WColor = new Color(255, 255, 255, 0.33f);

	public void Flash(int correctAnswer, int PlayerAnswer) {
		StartCoroutine(FlashPanels(correctAnswer, PlayerAnswer));
	}


	private IEnumerator FlashPanels(int correctAnswer, int PlayerAnswer) {

		int flashTimes = 0;


		while (flashTimes < 4) {

			if (PlayerAnswer == correctAnswer) {
				panels[PlayerAnswer].color = GColor;
			}
			else if (PlayerAnswer != correctAnswer) {
				panels[PlayerAnswer].color = RColor;

				for (int i = 0; i < 4; i++) {
					if (i == correctAnswer) {
						panels[i].color = GColor;
						continue;
					}
					//panels[i].color = RColor;
				}
			}

			yield return new WaitForSeconds(0.6f);
			panels[0].color = WColor;
			panels[1].color = WColor;
			panels[2].color = WColor;
			panels[3].color = WColor;
			yield return new WaitForSeconds(0.4f);
			flashTimes++;
		}

		yield return null;
		VR01_GameManager.instance.NextQuestion();
		yield return null;
	}

}
