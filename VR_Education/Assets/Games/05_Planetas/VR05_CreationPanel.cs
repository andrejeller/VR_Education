using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VR05_CreationPanel:MonoBehaviour {

	//THINGS TO IMPORT VIA UNITY
	public GameObject thePanel;
	public GameObject placeHolderSpheere;
	public GameObject fakeregua;
	public TextMeshProUGUI text;

	private Vector3 awayPosition;

	private int creationStep = 0;
	private float distance = 20.0f;

	private bool isActive = false;
	private bool stillCreating = false;


	//NEW PLANET
	private float _pSize;
	private float _pZpos;
	private VR05_Planeta theNewOne;

	private void Start() {
		CloseAndRestart();
	}

	public bool TogglePanel() {

		if (stillCreating)
			CancelOperation();

		isActive = !isActive;

		if (isActive) Open();
		else CloseAndRestart();

		return isActive;
	}

	private void Update() {

		if (!isActive) return;

		Transform pOrigin = VR05_GameManager.instance.pointer.GetOriginPosition();
		awayPosition = pOrigin.position + (pOrigin.forward * distance);

		Creation();

	}


	private void Creation() {

		//Press Touch - Restart

		text.text = Texts();

		switch (creationStep) {
			case 0:
			//DEBUG.dbg.Updt("step 0");
				//Choose Scale, arrasta em X
				fakeregua.SetActive(false);
				//DEBUG.dbg.Updt(awayPosition.ToString());
				float inputPositionX = awayPosition.x + 2;
				if (inputPositionX < 0) inputPositionX = 0;
				if (inputPositionX > 7) inputPositionX = 7;

				_pSize = Mathf.Lerp(1.0f, 30.0f, inputPositionX / 7);
				placeHolderSpheere.transform.localScale = new Vector3(_pSize, _pSize, _pSize);

				//Seleciona e avanca
				if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
					creationStep++;

				break;

			case 1:
			//DEBUG.dbg.Updt("step 1");
				//Choose  distancia em Z, arastanto para cima
				fakeregua.SetActive(true);
				float inputPositionZ = awayPosition.y - 15;
				if (inputPositionZ < 0) inputPositionZ = 0;
				if (inputPositionZ > 15) inputPositionZ = 15;

				_pZpos = Mathf.Lerp(15.0f, 180.0f, inputPositionZ / 15);
				placeHolderSpheere.transform.localPosition = new Vector3(0, 0, _pZpos);

				//DEBUG.dbg.Updt(awayPosition.ToString() + System.Environment.NewLine + _pZpos);


				if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
					creationStep++;

				break;


			case 2:
			//DEBUG.dbg.Updt("step 2");
				fakeregua.SetActive(false);
				placeHolderSpheere.SetActive(false);

				theNewOne = VR05_GameManager.instance.CreateNewPlanet(placeHolderSpheere.transform.localPosition, _pSize / 6, true);
				creationStep++;
				break;

			case 3:
			//DEBUG.dbg.Updt("step 3");
				//Grab
				//shoooot
				if (!theNewOne.holding && !theNewOne.onCreation) {

					//Fecha tudo e zera
					isActive = false;
					CloseAndRestart();
					stillCreating = false;
					theNewOne = null;
				}

				break;

		}

	}


	private void Open() {
		creationStep = 0;
		stillCreating = true;
		thePanel.SetActive(true);
		fakeregua.SetActive(false);
		placeHolderSpheere.SetActive(true);
		placeHolderSpheere.transform.position = new Vector3(0, 0, 15);
	}

	private void CloseAndRestart() {
		//isActive = false;
		creationStep = 0;
		thePanel.SetActive(false);
		fakeregua.SetActive(false);
		placeHolderSpheere.SetActive(false);
		placeHolderSpheere.transform.position = new Vector3(0, 0, 15);

	}

	private void CancelOperation() {
		CloseAndRestart();
		stillCreating = false;
		if (theNewOne) Destroy(theNewOne.gameObject);
	}


	private string Texts() {

		switch (creationStep) {
			case 0:
				return "GO RIGHT AND LEFT TO CHOOSE THE PLANET SIZE" + System.Environment.NewLine + "< -------------------------------------- >" + System.Environment.NewLine + System.Environment.NewLine + "THAN, PRESS THE TRIGGER TO SELECT IT";
			case 1:
				return "NOW, GO UP AND DOWN TO CHOOSE THE DISTANCE OF THE PLANET" + System.Environment.NewLine + System.Environment.NewLine + "v ^ v ^ v ^ v ^ v ^ v ^ v ^ v ^ v ^ v ^ v ^ v ^ v ^";
			case 3:
				return "FINALLY" + System.Environment.NewLine + "YOU CAN GRAB" + System.Environment.NewLine + System.Environment.NewLine;
			case 4:
				return System.Environment.NewLine + "NOW SHOOOOOOOT" + System.Environment.NewLine + System.Environment.NewLine;
		}

		return "";

	}

}
