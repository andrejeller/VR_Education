using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR13_GunScript : MonoBehaviour
{
	private Renderer render;
	public GameObject projectile;
	public GameObject spawnPoint;
	private Color colorBase;
	private int colorValue = 0;
	private List<Color> imageColors = new List<Color>();
	
	public LineRenderer laserLineRenderer;
	public float laserWidth = 0.1f;
	public float laserMaxLength = 5f;
	
	// Use this for initialization
	void Start () {
		render = GetComponent<Renderer>();
		
		Vector3[] initLaserPositions = new Vector3[ 2 ] { Vector3.zero, Vector3.zero };
		laserLineRenderer.SetPositions( initLaserPositions );
		laserLineRenderer.SetWidth( laserWidth, laserWidth );
		
	}
	
	// Update is called once per frame
	void Update () {
		Shot();
		SwitchColor();
		
		ShootLaserFromTargetPosition( spawnPoint.transform.position, transform.forward, laserMaxLength );
		/*if (hitinfo.collider.tag == "Grabable")
		{
			
		}*/
	}

	void Shot()
	{
		if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)|| Input.GetKey(KeyCode.Z))
		{
			var a = Instantiate(projectile, spawnPoint.transform.position, transform.rotation);
			a.GetComponent<Rigidbody>().AddForce(transform.forward * 5000);
			a.GetComponent<Renderer>().material.color = colorBase;
		}
		
		if (Input.GetKeyDown(KeyCode.D))
		{
			GameObject.Find("Canvas").GetComponent<VR13_Canvas>().GetImageColors(true);
			
			VR13_Bullet[] bulletInScreen;
			bulletInScreen = FindObjectsOfType<VR13_Bullet>();
			for (int clone =0; clone < bulletInScreen.Length ; clone++){
				Destroy(bulletInScreen[clone].gameObject);
			}
		}
	}

	public void UpdateColors(List<Color> allColors)
	{
		render = GetComponent<Renderer>();
		imageColors = allColors;
		colorBase = imageColors[0];
		render.materials[1].color = colorBase;
		
	}
	void SwitchColor()
	{
		if (imageColors.Count != 0)
		{
			if(OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyDown(KeyCode.X))
			{
				colorValue++;
				if (colorValue > imageColors.Count-1) colorValue = 0;
				colorBase = imageColors[colorValue];
				render.materials[1].color = colorBase;
			}
		}
	}
	
	void ShootLaserFromTargetPosition( Vector3 targetPosition, Vector3 direction, float length )
	{
		Ray ray = new Ray( targetPosition, direction );
		RaycastHit raycastHit;
		Vector3 endPosition = targetPosition + ( length * direction );
 
		if( Physics.Raycast( ray, out raycastHit, length ) ) {
			endPosition = raycastHit.point;
		}
 
		laserLineRenderer.SetPosition( 0, targetPosition );
		laserLineRenderer.SetPosition( 1, endPosition );
	}
}
