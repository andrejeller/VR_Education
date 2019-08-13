using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class VR12_BombDrop : MonoBehaviour {
    private int soltaABomba;
    public GameObject warningSign;
    public GameObject arrow;
    public GameObject airPlane;
    private float time;

	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.A) && soltaABomba == 0)
        {
            soltaABomba++;
            warningSign.SetActive(true);
            arrow.SetActive(true);
        }

        if (soltaABomba == 0)
        {
            time += Time.deltaTime;
            if (time > 2f)
            {
                time = 0;
                soltaABomba++;
                warningSign.SetActive(true);
                arrow.SetActive(true);
            }
        }
        

        if (soltaABomba == 1)
        {
            time += Time.deltaTime;
            if (time > 0.5f)
            {
                time = 0;
                warningSign.active = !warningSign.active;
            }
        }



        if (soltaABomba == 2)
        {
            airPlane.transform.DOMove(new Vector3(-12.23f, 81.15f, 256.14f), 2f).OnComplete(() => {
                airPlane.transform.DOMove(new Vector3(-0.5f, 85.2f, 254.7f), 15f);
                transform.SetParent(null);
                transform.DORotate(new Vector3(90, 90f, 0f), 2f);
                transform.DOMoveY(2f, 12f, false);
                soltaABomba = 3;
            }); ;
            airPlane.transform.DORotate(new Vector3(-109.466f, 0f, 90f), 2f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player"&& soltaABomba ==1)
        {
            soltaABomba = 2;
        }
    }
}
