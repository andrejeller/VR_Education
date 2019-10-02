using UnityEngine;
using System.Collections;
using DG.Tweening;

public class RobotTestScriptFree : MonoBehaviour {

	private Animator anim;
	private float jumpTimer = 0;
    public int stepAnimationOrder = 0;
    public GameObject[] stepreference;
    public GameObject key;
    public GameObject porta;

	void Start () {
	
		anim = this.gameObject.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

        //Controls the Input for running animations
        // 1: walk
        //2: Run
        //3: Jump

        if (stepAnimationOrder == 1)
        {
            var yy = transform.position.y;

            anim.SetInteger("Speed", 1);
            transform.DOMove(stepreference[0].transform.position, 1f, false).OnComplete(() =>
            {
                lookAt(stepreference[1]);
                transform.DOMove(stepreference[1].transform.position, 6f, false).OnComplete(() =>
                {
                    lookAt(stepreference[2]);
                    transform.DOMove(stepreference[2].transform.position, 2f, false).OnComplete(() =>
                    {
                        lookAt(stepreference[3]);
                        transform.DOMove(stepreference[3].transform.position, 4f, false).OnComplete(() =>
                        {
                            Destroy(key);
                            lookAt(stepreference[4]);
                            transform.DOMove(stepreference[2].transform.position, 4f, false).OnComplete(() =>
                            {
                                ////abrir porta
                                porta.transform.DORotate(new Vector3(0f,-180f),2f);
                                transform.DOMove(stepreference[4].transform.position, 2f, false).OnComplete(() =>
                                {
                                });
                            });
                        });
                    });
                });
            });

            stepAnimationOrder = 2;
        }
	}



    private void lookAt(GameObject target)
    {
        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
    }
}
