using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VR01_GameManager : MonoBehaviour {

    public static VR01_GameManager instance;

    public Text txt_Question;
    public Text txt_Awnser1;
    public Text txt_Awnser2;
    public Text txt_Awnser3;
    public Text txt_Awnser4;

    private int ActualAwnser;

    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }




    public void AwnserButtonClicked(int id) {
        if (id == ActualAwnser) {

        }
    }

    //Translate A,B,C,D to 0,1,2,3
}
