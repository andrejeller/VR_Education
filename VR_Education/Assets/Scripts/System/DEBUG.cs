using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DEBUG:MonoBehaviour {

	public Text debugText;

	public static DEBUG dbg;

	private void Awake() {

		if (dbg == null) dbg = this;
		else Destroy(gameObject);

	}

	public void Updt(string dbg) {
		//string oldTxt = debugText.text;
		//debugText.text = oldTxt + System.Environment.NewLine + System.Environment.NewLine + dbg;
		debugText.text = dbg;
	}
}
