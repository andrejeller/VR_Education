using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class VR13_Canvas : MonoBehaviour
{
	private int width, height;
	public List<Color> imageColors = new List<Color>();
	public GameObject pixelOBJ;
	public GameObject paintGun;
	public Texture2D[] sprites;
	public int currentTexture;
	public Text txt;
	private float currentCorrects = 0;
	private float numberOfAllPixelObjects;

	private GameObject[,] allPixelObj;
	
	// Use this for initialization
	void Start ()
	{
		
		GetImageColors(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void correctPercent(int Opa)
	{
		if (Opa == 999)
		{
			Opa = 0;
			currentCorrects = 0;
		}
		currentCorrects += Opa;
		Debug.Log(allPixelObj.GetLength(0));
		txt.text = (Mathf.Abs(currentCorrects-numberOfAllPixelObjects)).ToString();
	}
	public void GetImageColors(bool changeObj)
	{
		if (changeObj)
		{
			currentTexture++;
			if (currentTexture > sprites.Length-1) currentTexture = 0;
		}
		
		var rotacaoInitial = transform.rotation;
		transform.rotation = Quaternion.identity;
		
		
		var clones = GameObject.FindGameObjectsWithTag ("Grabable");
		for (int clone =0; clone < clones.Length ; clone++){
			Destroy(clones[clone]);
		}
		
		width = sprites[currentTexture].width;
		height = sprites[currentTexture].height;
		Debug.Log("Width "+ width);
		Debug.Log("Height "+ height);
		allPixelObj = new GameObject[height,width];
		float initialWidth = transform.position.x - (0.378f*width/2);
		float initialHeight = transform.position.y - (0.378f*height/2);
		float widthOfOnePixel = 0.378f;
		float heightOfOnePixel = 0.378f;
		numberOfAllPixelObjects = 0;
		currentCorrects = 0;
		imageColors.Clear();
		for (int j = 0; j < height; j++)
		{
			for (int i = 0; i < width; i++)
			{
				if (sprites[currentTexture].GetPixel(i, j).a == 1f)
				{
					allPixelObj[height-1,width-1] = Instantiate(pixelOBJ,new Vector3(initialWidth+(widthOfOnePixel*i),initialHeight+(widthOfOnePixel*j),transform.position.z),transform.rotation);
					numberOfAllPixelObjects++;
					allPixelObj[height-1,width-1].transform.Rotate(90f,0f,0f);
					allPixelObj[height-1,width-1].transform.SetParent(transform);
					allPixelObj[height-1,width-1].GetComponent<VR13_PixelCanvas>().updateCorrectColor(sprites[currentTexture].GetPixel(i, j));
					
					if (imageColors.Count == 0)
					{
						imageColors.Add(sprites[currentTexture].GetPixel(i, j));
						
					}
					else
					{
						Debug.Log("Entrei no Else");
						if(!imageColors.Contains(sprites[currentTexture].GetPixel(i, j)))
						{
							imageColors.Add(sprites[currentTexture].GetPixel(i, j));
						}
						
					}
				}
			}
		}
		paintGun.GetComponent<VR13_GunScript>().UpdateColors(imageColors);
		transform.rotation = rotacaoInitial;
		correctPercent(999);
		txt.text = (Mathf.Abs(currentCorrects-numberOfAllPixelObjects)).ToString();
	}
	

}
