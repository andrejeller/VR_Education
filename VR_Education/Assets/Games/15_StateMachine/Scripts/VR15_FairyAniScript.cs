using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR15_FairyAniScript : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack1()
    {
        anim.SetTrigger("Attack1");
    }

    public void Attack5()
    {
        anim.SetTrigger("Attack5");
    }

    public void Victory()
    {
        anim.SetTrigger("Victory");
    }

    public void Sleep()
    {
        anim.SetTrigger("Sleep");
    }

    public void Attack4()
    {
        anim.SetTrigger("Attack4");
    }

    public void Attack8()
    {
        anim.SetTrigger("Attack8");
    }

    public void Walk()
    {
        anim.SetTrigger("Walk");
    }
    public void Attack3()
    {
        anim.SetTrigger("Attack3");
    }

    public void Attack7()
    {
        anim.SetTrigger("Attack7");
    }

    public void Special()
    {
        anim.SetTrigger("Special");
    }

    public void Hurt()
    {
        anim.SetTrigger("Hurt");
    }
    public void Attack2()
    {
        anim.SetTrigger("Attack2");
    }

    public void Attack6()
    {
        anim.SetTrigger("Attack6");
    }

    public void Show()
    {
        anim.SetTrigger("Show");
    }

    public void Stun()
    {
        anim.SetTrigger("Stun");
    }

    public void Idle()
    {
        anim.SetTrigger("Idle");
    }
}
