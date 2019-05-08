using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SelectGameButton : MonoBehaviour {

	public void ClickMe(int gameID) {
        SceneLoader.instance.Load(gameID);
    }
}
