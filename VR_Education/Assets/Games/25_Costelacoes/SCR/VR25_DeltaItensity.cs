using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR25_DeltaItensity : MonoBehaviour {
    public Light lgtSys;
    private float xx;
    public float value;
    public float variance;
	void Update () {

        lgtSys.intensity = value + variance * Mathf.Sin(xx);
        xx = xx+Time.deltaTime;

    }
}
