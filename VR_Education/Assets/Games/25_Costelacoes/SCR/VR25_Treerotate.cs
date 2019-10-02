using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR25_Treerotate : MonoBehaviour {
    private int dir;
    public float range;
	// Use this for initialization
	void Start () {
        dir = Mathf.RoundToInt(Random.Range(0, 1));
        if(dir == 0)
        {
            dir = -1;
        }
        doMagicBaby();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void doMagicBaby()
    {
        var truerange = Random.Range(-range, range);
        transform.DOLocalRotate(new Vector3(truerange * dir, 0f, truerange * -dir), 1f,RotateMode.LocalAxisAdd).OnComplete(() =>
        {
            dir *= -1;
            doMagicBaby();
        });
    }
}
