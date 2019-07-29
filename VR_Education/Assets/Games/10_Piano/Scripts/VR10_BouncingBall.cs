using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VR10_BouncingBall : MonoBehaviour
{
	[System.Serializable]
	public struct Note
	{
		public GameObject tecla;
		public float timeToPlayNote;

		public Note(GameObject obj, float val)
		{
			tecla = obj;
			timeToPlayNote = val;
		}
	}


	public int currentNote;
	public GameObject[] noteList;
	public Note[] notes;
	public ParticleSystem partsys;

	private bool playSong;
	private float songTime=0f;
	private int currentAutoNote;
	private float currentAutoNoteTime;

	private Rigidbody rg;
	// Use this for initialization
	void Start ()
	{
		rg = GetComponent<Rigidbody>();
		transform.DOLocalMoveX(noteList[currentNote].transform.position.x,0.5f);
		//playSong = true;
		//partsys.gameObject.SetActive(true);
		//currentAutoNoteTime = notes[currentAutoNote].timeToPlayNote;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -0.48f)
		{
			transform.position = new Vector3(transform.position.x,-0.48f,transform.position.z);
			rg.velocity = Vector3.zero;
			rg.AddForce(0f,500f,0f);
		}

		playEntireSong();
	}

	public void changeCurrentOBJtoFollow(GameObject note)
	{
		if (playSong) return;
		if (note == noteList[currentNote])
		{
			currentNote++;
			if (currentNote > noteList.Length-1){
				currentNote = 0;
				playSong = true;
				partsys.gameObject.SetActive(true);
				return;
			}
			
			
			
			transform.DOLocalMoveY(-0.48f,0.05f);
			rg.velocity = Vector3.zero;
			rg.AddForce(0f,500f,0f);
			transform.DOLocalMoveX(noteList[currentNote].transform.position.x,0.5f);
		}
		else
		{
			if (currentNote != 0)
			{
				transform.DOLocalMoveY(-0.48f,0.05f);
				rg.velocity = Vector3.zero;
				rg.AddForce(0f,500f,0f);
				currentNote = 0;
			}
			transform.DOLocalMoveX(noteList[currentNote].transform.position.x,0.5f);
		}
	}

	void playEntireSong(){
		if(!playSong) return;
		songTime += Time.deltaTime;

		if (songTime > currentAutoNoteTime)
		{
			notes[currentAutoNote].tecla.GetComponent<VR10_PianoKeyScript>().BeingPressed();

			transform.DOLocalMoveY(-0.48f, 0.05f);
			rg.velocity = Vector3.zero;
			rg.AddForce(0f, 500f, 0f);
			transform.DOLocalMoveX(notes[currentAutoNote].tecla.transform.position.x, 0.2f);

			currentAutoNote++;




			if (currentAutoNote > notes.Length - 1)
			{
				currentAutoNote = 0;
				currentAutoNoteTime = notes[currentAutoNote].timeToPlayNote;
				playSong = false;
				partsys.gameObject.SetActive(false);
				songTime = 0f;

			}
			else
			{
				currentAutoNoteTime += notes[currentAutoNote].timeToPlayNote;
			}
			
		}


	}
}

