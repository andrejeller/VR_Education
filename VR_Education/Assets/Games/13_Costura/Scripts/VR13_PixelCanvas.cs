using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR13_PixelCanvas : MonoBehaviour
{
	private Color correctColor;
	private Renderer render;
	private bool alreadyCorrect = false;
	// Use this for initialization
	void Start () {
		render = GetComponent<Renderer>();
	}
	
	
	// Update is called once per frame
	public void updateCorrectColor(Color correctColor)
	{
		this.correctColor = correctColor;
	}
	public int compareColors ()
	{
		if (correctColor == render.materials[1].color&& !alreadyCorrect)
		{
			alreadyCorrect = true;
			return (1);
		}
		
		if (correctColor != render.materials[1].color && alreadyCorrect)
		{
			alreadyCorrect = false;
			return (-1);
		}
		return (0);
	}
}
