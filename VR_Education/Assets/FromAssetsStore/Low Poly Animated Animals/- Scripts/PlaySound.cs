using UnityEngine;

namespace LowPolyAnimalPack
{
  public class PlaySound : MonoBehaviour
  {
    [SerializeField]
    private AudioClip animalSound;
    [SerializeField]
    private AudioClip walking;
    [SerializeField]
    private AudioClip eating;
    [SerializeField]
    private AudioClip running;
    [SerializeField]
    private AudioClip attacking;
    [SerializeField]
    private AudioClip death;
    [SerializeField]
    private AudioClip sleeping;
    [SerializeField]
    private AudioSource AudioSource;

    void AnimalSound()
    {
      if (animalSound)
      {
        //AudioManager.PlaySound(animalSound, transform.position);
        AudioSource.PlayOneShot(animalSound);
                //randomize
                //Random.Range(10, 100);
                //AudioSource.PlayClipAtPoint(animalSound, )
      }
    }

    void Walking()
    {
      if (walking)
      {
        //AudioManager.PlaySound(walking, transform.position);
        AudioSource.PlayOneShot(walking);
      }
    }

    void Eating()
    {
      if (eating)
      {
        //AudioManager.PlaySound(eating, transform.position);
        AudioSource.PlayOneShot(eating);
      }
    }

    void Running()
    {
      if (running)
      {
        //AudioManager.PlaySound(running, transform.position);
        AudioSource.PlayOneShot(running);
      }
    }

    void Attacking()
    {
      if (attacking)
      {
        //AudioManager.PlaySound(attacking, transform.position);
        AudioSource.PlayOneShot(attacking);
      }
    }

    void Death()
    {
      if (death)
      {
        //AudioManager.PlaySound(death, transform.position);
        AudioSource.PlayOneShot(death);
      }
    }

    void Sleeping()
    {
      if (sleeping)
      {
        //AudioManager.PlaySound(sleeping, transform.position);
        AudioSource.PlayOneShot(sleeping);
      }
    }
  }
}