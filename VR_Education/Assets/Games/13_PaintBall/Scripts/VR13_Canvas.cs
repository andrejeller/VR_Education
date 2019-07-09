using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class VR13_Canvas : MonoBehaviour
{
	private int width, height;
	public List<Color> imageColors = new List<Color>();
	public GameObject pixelOBJ;
	public GameObject paintGun;
	public Texture2D[] sprites;
	public int currentTexture;

	private GameObject[,] allPixelObj;
	
	// Use this for initialization
	void Start ()
	{
		
		GetImageColors(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetImageColors(bool changeObj)
	{
		if (changeObj)
		{
			currentTexture++;
		}
		
		var rotacaoInitial = transform.rotation;
		transform.rotation = Quaternion.identity;
		
		
		var clones = GameObject.FindGameObjectsWithTag ("Grabable");
		for (int clone =0; clone < clones.Length ; clone++){
			Destroy(clones[clone]);
		}
		
		
		
		while (GameObject.Find("VR13_pixelblock(Clone)") != null)
		{
			Destroy(GameObject.Find("VR13_pixelblock(Clone)"));
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
		
		
		for (int j = 0; j < height; j++)
		{
			for (int i = 0; i < width; i++)
			{
				if (sprites[currentTexture].GetPixel(i, j).a == 1f)
				{
					allPixelObj[height-1,width-1] = Instantiate(pixelOBJ,new Vector3(initialWidth+(widthOfOnePixel*i),initialHeight+(widthOfOnePixel*j),transform.position.z),transform.rotation);
					allPixelObj[height-1,width-1].transform.Rotate(90f,0f,0f);
					allPixelObj[height-1,width-1].transform.SetParent(transform);
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
	}
	

}
