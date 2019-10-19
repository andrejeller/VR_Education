using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[SelectionBase]
public class VR16_Botao : MonoBehaviour, IInteractable {


	public AudioClip animalSound;
    public AudioSource AudioSource;
	public Animator[] anim;
	

	public IEnumerable OnPointerOver() {
		transform.DOScale(new Vector3(4, 40, 220), 0.2f);
		yield return null;
	}

	public IEnumerable OnPointerExit() {
		transform.DOScale(new Vector3(2, 40, 200), 0.2f);

        //VR16_GameManager.instance.Play(animalSound);
        AudioSource.PlayOneShot(animalSound);
        for (int i = 0; i < anim.Length; i++)
            anim[i].SetBool("isDead", true);

        yield return new WaitForSeconds(3.0f);

        for (int i = 0; i < anim.Length; i++)
            anim[i].SetBool("isDead", false);

        yield return null;
	}

	public IEnumerable OnTriggerPress() {
		VR16_GameManager.instance.Play(animalSound);
		for (int i = 0; i < anim.Length; i++)
			anim[i].SetBool("isDead", true);

		yield return new WaitForSeconds(3.0f);

		for (int i = 0; i < anim.Length; i++)
			anim[i].SetBool("isDead", false);

		yield return null;
	}






	public IEnumerable OnTriggerHold() {
		throw new System.NotImplementedException();
	}
	public IEnumerable OnTriggerRelease() {
		throw new System.NotImplementedException();
	}

	
}

