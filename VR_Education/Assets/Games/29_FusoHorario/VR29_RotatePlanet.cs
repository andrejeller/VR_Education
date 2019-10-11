using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VR29_RotatePlanet : MonoBehaviour
{

    Quaternion planetRotation;
    public float dist = 400;
    public float targetRadius = 100;
    public float dayTime;
    public float divisionScale;
    private LineRenderer _ln;
    public GameObject sphere;
    public GameObject playerHand;
    public Text textTime;
    public bool canDrag;

    public GameObject referenceEmpty;
    public GameObject actualCreatedObj;

    void Start()
    {
        planetRotation = transform.rotation;
        _ln = playerHand.transform.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


        RaycastHit hito;

        if (Physics.Raycast(playerHand.transform.position, playerHand.transform.TransformDirection(Vector3.forward), out hito))
        {
            Debug.Log("WTFFFFFFFFFFF");
            _ln.useWorldSpace = true;
            _ln.SetPosition(0, playerHand.transform.position);
            _ln.SetPosition(1, hito.point);
            sphere.transform.position = hito.point;
        }
        else
        {
            _ln.useWorldSpace = false;
            _ln.SetPosition(0, Vector3.zero);
            _ln.SetPosition(1, new Vector3(0f, 0f, 100f));
            sphere.transform.position = new Vector3(999f, 999f, 999f);
        }



#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Hammer" && actualCreatedObj == null)
                {
                    actualCreatedObj = Instantiate(referenceEmpty, hit.point, transform.rotation);


                }

            }





            if (actualCreatedObj != null)
            {
                float xMove = Input.GetAxis("Mouse X");

                float rotateSensitivity = Mathf.Min(2f, (float)((dist - targetRadius) / targetRadius) * 1.2f);
                planetRotation *= Quaternion.AngleAxis(rotateSensitivity * -xMove, Vector3.up);
            }

        }
        else
        {
            if (actualCreatedObj != null)
            {
                Destroy(actualCreatedObj);
            }
        }










#elif UNITY_ANDROID











        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            Ray ray;
            RaycastHit hit;

            if (Physics.Raycast(playerHand.transform.position, playerHand.transform.TransformDirection(Vector3.forward), out hit))
            {
                if (hit.collider.gameObject.tag == "Hammer" && actualCreatedObj ==null)
                {
                    actualCreatedObj = Instantiate(referenceEmpty, hit.point, transform.rotation);
                }
            }


            if (actualCreatedObj != null)
            {
                float xMove = Input.GetAxis("Mouse X");

                float rotateSensitivity = Mathf.Min(2f, (float)((dist - targetRadius) / targetRadius) * 1.2f);
                planetRotation *= Quaternion.AngleAxis(rotateSensitivity * -xMove, Vector3.up);
            }

        }
        else
        {
            if (actualCreatedObj != null)
            {
                Destroy(actualCreatedObj);
            }
        }





#endif






























        transform.rotation = planetRotation;
        var a = transform.localRotation.eulerAngles.y - 180f;
        
        dayTime = Mathf.Floor(a/ divisionScale);
        Debug.Log("angulo y raw = "+ transform.localRotation.eulerAngles.y +" calculo do a= "+ a+ " calculo do daytime= "+dayTime);
        if (dayTime == -12f) dayTime = 12f;
        textTime.text = ("Fuso Horario atual: "+dayTime+" UTC.");
    }
}
