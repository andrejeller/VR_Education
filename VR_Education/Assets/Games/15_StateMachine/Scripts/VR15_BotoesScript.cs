using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class VR15_BotoesScript : MonoBehaviour
{
    bool m_targeted = false;
    public int animationNumber = 0;

    public VR15_FairyAniScript ladyAutumnScript;

    // Inicialização
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (m_targeted == true)
        {
            switch (animationNumber)
            {
                case 0:
                    ladyAutumnScript.Attack1();
                    break;
                case 1:
                    ladyAutumnScript.Attack2();
                    break;
                case 2:
                    ladyAutumnScript.Attack3();
                    break;
                case 3:
                    ladyAutumnScript.Attack4();
                    break;
                case 4:
                    ladyAutumnScript.Attack5();
                    break;
                case 5:
                    ladyAutumnScript.Attack6();
                    break;
                case 6:
                    ladyAutumnScript.Attack7();
                    break;
                case 7:
                    ladyAutumnScript.Attack8();
                    break;
                case 8:
                    ladyAutumnScript.Victory();
                    break;
                case 9:
                    ladyAutumnScript.Sleep();
                    break;
                case 10:
                    ladyAutumnScript.Show();
                    break;
                case 11:
                    ladyAutumnScript.Stun();
                    break;
                case 12:
                    ladyAutumnScript.Special();
                    break;
                case 13:
                    ladyAutumnScript.Hurt();
                    break;
                case 14:
                    ladyAutumnScript.Walk();
                    break;
            }
            
        }

        else
        {
            ladyAutumnScript.Idle();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Olhou para o objeto

        if(other.tag == "Hammer")
        {
            m_targeted = true;
            Debug.Log("To olhando");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        // Parou de olhar pra o objeto
        if (other.tag == "Hammer")
        {
            m_targeted = false;
        }
    }
}
