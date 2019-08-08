using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR05_GameManager:MonoBehaviour {

	public static VR05_GameManager instance;
	private void Awake() {
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}

	[Header("Initials")]
	public GameObject sun;
	public GameObject center;
	public GameObject planetPrefab;

	[Header("Planet Materials")]
	public Material[] planetMaterials;
	[HideInInspector]
	public List<VR05_Planeta> ActivePlanets = new List<VR05_Planeta>();

	[Space]
	public Pointer pointer;

	[Space]
	[Header("Planet Creation")]
	public GameObject creation;
	private bool creationTime;
	public VR05_CreationPanel cPanel;

	private void Start() {
		//GameObject theSun = Instantiate(sun, new Vector3(-1300, 86, 2360), Quaternion.identity, center.transform);
		//theSun.GetComponent<VR05_Planeta>().isTheSun = true;

		//CreateInitialsPlanets();
		ActivePlanets.Add(sun.GetComponent<VR05_Planeta>());
		pointer.Distance = 2700.0f;
		//Debug.Log(Vector3.Distance(center.transform.position, sun.transform.position));
	}


	private void Update() {
		if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Q)) {
			creationTime = cPanel.TogglePanel();
		}

	}


	public VR05_Planeta CreateNewPlanet(Vector3 pos, float size, bool theSun) {
		//Vector3 pos = new Vector3(Random.Range(-500, 500), Random.Range(-500, 500), Random.Range(-500, 500));

		GameObject newPlanet = Instantiate(planetPrefab, pos, Quaternion.identity, center.transform);

		newPlanet.GetComponent<Renderer>().material = planetMaterials[Random.Range(0, planetMaterials.Length)];
		VR05_Planeta a = newPlanet.GetComponent<VR05_Planeta>();
		a.Initialize(size);
		a.isTheSun = theSun;
		a.onCreation = true;

		ActivePlanets.Add(a);
		return a;
	}

	private void CreateInitialsPlanets() {
		for (int i = 0; i < 15; i++) {

			Vector3 pos = new Vector3(Random.Range(-500, 500), Random.Range(-500, 500), Random.Range(-500, 500));

			GameObject newPlanet = Instantiate(planetPrefab, pos, Quaternion.identity, center.transform);

			VR05_Planeta a = newPlanet.GetComponent<VR05_Planeta>();
			a.Initialize(Random.Range(3.0f, 10.0f));


			ActivePlanets.Add(a);

		}
	}

}
