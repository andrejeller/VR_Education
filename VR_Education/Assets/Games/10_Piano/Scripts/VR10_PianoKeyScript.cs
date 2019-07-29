using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR10_PianoKeyScript : MonoBehaviour
{
    public AudioSource audiosorce;
    public GameObject bouncingBall;

    private bool canBePressed = true;
    private float yy;
    private Renderer rend;

    public float semitone_offset = 0;
    // Use this for initialization
    void Start()
    {
        yy = transform.localPosition.y;
        rend = transform.GetComponent<Renderer>();
        audiosorce.pitch = Mathf.Pow(2f, semitone_offset / 12.0f);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!canBePressed)
		{
			transform.DOMoveX(transform.position.x, 1.3f).OnComplete(() => { canBePressed = true; });
		}*/
    }


    private void OnMouseEnter()
    {
        BeingPressed();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            BeingPressed();
        }
        else if (other.tag == "Grabable")
        {
            rend.material.color = new Color(144f / 255f, 1f, 230f / 255f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grabable")
        {
            canBePressed = true;
            rend.material.color = new Color(1f, 1f, 1f);
        }
    }

    public void BeingPressed()
    {
        bouncingBall.GetComponent<VR10_BouncingBall>().changeCurrentOBJtoFollow(gameObject);

        canBePressed = false;
        audiosorce.Play();
        transform.DOLocalRotate(new Vector3(-8.344001f, 0f, 0f), 0.3f);

        transform.DOLocalMoveY(yy - 0.3f, 0.3f, false).OnComplete(() =>
        {
            transform.DOLocalMoveY(yy, 0.3f, false).OnPlay(() =>
            {
                transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 0.3f);
            });

        });
    }
}
