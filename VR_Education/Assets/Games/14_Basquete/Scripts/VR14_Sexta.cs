using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR14_Sexta : MonoBehaviour {


	public GameObject fireWorks;

	private void OnTriggerExit(Collider other) {
		//VR14_GameManager.instance.FireWorks();
		GameObject fired = Instantiate(fireWorks, new Vector3(transform.position.x, 40.0f,transform.position.z), Quaternion.identity);
		Destroy(fired, 1.0f);
	}

}
