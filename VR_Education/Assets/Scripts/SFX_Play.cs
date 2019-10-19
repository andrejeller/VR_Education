using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum sfxs { None, PlayOneShot_OnAwake, PlayLoop_OnAwake}


[AddComponentMenu("FMOD Studio/FMOD Studio Event Emitter")]
public class SFX_Play : MonoBehaviour
{

    public SFX_Player SFX_Player;
    public sfxs sfxs = sfxs.None;

    // Use this for initialization
    void Start()
    {
        if (sfxs == sfxs.None)
            None();

        if (sfxs == sfxs.PlayOneShot_OnAwake)
            SFX_PlayOneShot_OnAwake(0, 1, 0);

        if (sfxs == sfxs.PlayLoop_OnAwake)
            SFX_PlayLoop_OnAwake(0, 1, 0);

    }

    // Update is called once per frame
    void Update()
    {


    }



    public void None()
    {

    }
    public void SFX_PlayOneShot_OnAwake(int SFX_Number, float SFX_Volume, int AudioSource_Number)
    {
        if (SFX_Player.SFX[SFX_Number])
        {
            SFX_Player.AudioSource[AudioSource_Number].PlayOneShot(SFX_Player.SFX[SFX_Number], SFX_Volume);
        }
    }

    public void SFX_PlayLoop_OnAwake(int SFX_Number, float SFX_Volume, int AudioSource_Number)
    {
        if (SFX_Player.SFX[SFX_Number])
        {
            SFX_Player.AudioSource[AudioSource_Number].PlayOneShot(SFX_Player.SFX[SFX_Number], SFX_Volume);
        }
    }
    /*
    public void SFX_Play_OnCollision(int SFX_Number, float SFX_Volume, int AudioSource_Number)
    {
        if (SFX_Player.SFX[SFX_Number])
        {
            SFX_Player.AudioSource[AudioSource_Number].PlayOneShot(SFX_Player.SFX[SFX_Number], SFX_Volume);
        }
    }

    void OnCollisionEnter()  //Plays Sound Whenever collision detected
    {
        SFX_Player.AudioSource[AudioSource_Number].PlayOneShot(SFX_Player.SFX[SFX_Number], SFX_Volume);
    }
    */
}
