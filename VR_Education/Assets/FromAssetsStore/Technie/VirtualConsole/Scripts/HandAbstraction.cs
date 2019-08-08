using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Technie.VirtualConsole
{
	public class HandAbstraction : MonoBehaviour
	{
		public VirtualConsole virtualConsole;

		public Material ballMaterial;
		public Material laserMaterial;

		public Sprite cursorSprite;
		public Material cursorMaterial;

		public XrNodeRig xrRig;
		public PanelManager panelManager;

	//	public SteamVrBinding steamVrBinding;
	//	public PsVrBinding psvrBinding;
	//	public ManualBinding manualBinding;

		// Internal State

		private WandInputModule wandInputModule;

	//	private ApiBinding activeBinding;

		private Hand leftHand, rightHand;

	//	private UiLaser leftLaser;
	//	private UiLaser rightLaser;

		private UiStylus leftStylus;
		private UiStylus rightStylus;

		private bool wasLeftDown;
		private bool wasRightDown;

	//	private bool triggerLeft;
	//	private bool triggerRight;

		private float findHandsTimer;

		void OnEnable()
		{

		}
		
		void OnDisable()
		{

		}

		void Start()
		{
			// Always call this on start so we refetch hands if we're dynamically loaded as a prefab after SteamVR has sent all of it's controller events

			FindHands();
		}

		private void FindHands()
		{
			// Lazily create the wand input module

			if (wandInputModule == null)
			{
				GameObject eventSystemObj = new GameObject("Isolated Event System");
				eventSystemObj.transform.SetParent(this.transform, false);

				eventSystemObj.gameObject.AddComponent<IsolatedEventSystem>();

				wandInputModule = eventSystemObj.gameObject.AddComponent<WandInputModule>();
				wandInputModule.CursorSprite = cursorSprite;
				wandInputModule.CursorMaterial = cursorMaterial;
			}

			// Lazily create the lasers

		//	if (leftLaser == null)
		//	{
		//		leftLaser = CreateLaser();
		//	}
		//	if (rightLaser == null)
		//	{
		//		rightLaser = CreateLaser();
		//	}

			if (leftStylus == null)
			{
				leftStylus = CreateStylus(HandType.Left, xrRig.leftHandTransform, wandInputModule);

			//	leftStylus.transform.localPosition = new Vector3(0.0f, -0.01f, -0.18f);
			//	leftStylus.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);

				SetStylusPosition(leftStylus, HandType.Left, virtualConsole.leftStylusPosition, virtualConsole.customLeftStylusPosition);
			}

			if (rightStylus == null)
			{
				rightStylus = CreateStylus(HandType.Right, xrRig.rightHandTransform, wandInputModule);

			//	rightStylus.transform.localPosition = new Vector3(0.0f, -0.01f, -0.18f);
			//	rightStylus.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);

				SetStylusPosition(rightStylus, HandType.Right, virtualConsole.rightStylusPosition, virtualConsole.customRightStylusPosition);

			//	rightStylus.gameObject.SetActive(false);
			}
			/*
			if (leftHand == null)
			{
				leftHand = CreateHand();
			}
			if (rightHand == null)
			{
				rightHand = CreateHand();
			}
			*/
			wandInputModule = GameObject.FindObjectOfType(typeof(WandInputModule)) as WandInputModule;
			wandInputModule.SetRaycastOrigins(leftStylus.transform, rightStylus.transform);

			// Do Api specific binding
			/*
			if (activeBinding == null)
			{
				// No active binding, try all known bindings to see what catches on

				if (steamVrBinding != null && steamVrBinding.FindHands () > 0)
				{
					// SteamVR found hands, so use SteamVR from now on
					activeBinding = steamVrBinding;
				}
				else if (psvrBinding != null && psvrBinding.FindHands () > 0) // null ref here
				{
					activeBinding = psvrBinding;
				}
				else if (manualBinding != null && manualBinding.FindHands () > 0)
				{
					activeBinding = manualBinding;
				}
				// other api bindings here...
			}
			else
			{
				// We have an active binding, check it again to see if it found any more hands
				activeBinding.FindHands();
			}
			*/
		//	if (activeBinding != null)
		//	{
				// We have a new binding, so hook up all the things

			//	BindHand(activeBinding.LeftHand, leftHand, HandType.Left);
			//	BindHand(activeBinding.RightHand, rightHand, HandType.Right);
//
//				wandInputModule = GameObject.FindObjectOfType(typeof(WandInputModule)) as WandInputModule;
//				if (wandInputModule != null)
//				{
//					wandInputModule.OnHandsDetected(this);
//				}
				
			//	leftLaser.OnHandDetected(activeBinding.LeftHandIndex, activeBinding.LeftHand, wandInputModule);
			//	rightLaser.OnHandDetected(activeBinding.RightHandIndex, activeBinding.RightHand, wandInputModule);
				
			//	VrDebugDisplay[] displays = GameObject.FindObjectsOfType(typeof(VrDebugDisplay)) as VrDebugDisplay[];
			//	foreach (VrDebugDisplay display in displays)
			//	{
			//		display.OnHandsDetected(this, wandInputModule.GetControllerCamera());
			//	}
		//	}

			wandInputModule.OnHandsDetected(this); // Needed to initialise input module

			panelManager.OnHandsDetected(wandInputModule.GetControllerCamera());
		}

		private UiLaser CreateLaser()
		{
			GameObject laser = new GameObject ("Ui Laser");
			laser.transform.SetParent (this.transform, false);

			UiLaser laserComponent = laser.AddComponent<UiLaser> ();
			laserComponent.CreateBeam (laserMaterial);

			return laserComponent;
		}

		private UiStylus CreateStylus(HandType type, Transform handTransform, WandInputModule inputModule)
		{
			GameObject obj = new GameObject("Ui Stylus");
			obj.transform.SetParent(handTransform, false);

			UiStylus stylus = obj.AddComponent<UiStylus>();
			stylus.laserMaterial = laserMaterial;
			stylus.ballMaterial = ballMaterial;
			stylus.handType = type;
			stylus.inputModule = inputModule;

			return stylus;
		}

		private void SetStylusPosition(UiStylus stylus, HandType hand, StylusPosition stylusPosition, Vector3 customStylusPosition)
		{
			switch (stylusPosition)
			{
				case StylusPosition.Top:
				{
					stylus.transform.localPosition = new Vector3(0.0f, 0.0f, 0.05f);
					break;
				}
				case StylusPosition.Bottom:
				{
					stylus.transform.localPosition = new Vector3(0.0f, -0.01f, -0.18f);
					break;
				}
				case StylusPosition.Left:
				{
					stylus.transform.localPosition = new Vector3(-0.085f, -0.01f, -0.01f);
					break;
				}
				case StylusPosition.Right:
				{
					stylus.transform.localPosition = new Vector3( 0.085f, -0.01f, -0.01f);
					break;
				}
				case StylusPosition.Custom:
				{
					stylus.transform.localPosition = customStylusPosition;
					break;
				}
			}
			
		//	stylus.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
		}
		/*
		private Hand CreateHand()
		{
			GameObject handObj = new GameObject ("Hand");
			handObj.transform.SetParent (this.transform, false);
			
			Hand handComponent = handObj.AddComponent<Hand> ();
			
			return handComponent;
		}
		*/
		public GameObject GetLeftHand()
		{
		//	if (activeBinding != null)
		//		return activeBinding.LeftHand;
			return null;
		}

		public GameObject GetRightHand()
		{
		//	if (activeBinding != null)
		//		return activeBinding.RightHand;
			return null;
		}

		/*
		private void BindHand(GameObject trackedTransform, Hand attachedHand, HandType type)
		{
			if (trackedTransform != null)
			{
				attachedHand.trackedTransform = trackedTransform.transform;
				attachedHand.type = type;
				attachedHand.gameObject.SetActive(true);
			}
			else
			{
				attachedHand.trackedTransform = null;
				attachedHand.type = HandType.Invalid;
				attachedHand.gameObject.SetActive(false);
			}
		}
		*/

		void Update()
		{
			/*
			// If we don't have both hands then keep checking every second until we do (since SteamVR can be a bit slow sometimes)
			if (activeBinding == null || activeBinding.LeftHand == null || activeBinding.RightHand == null)
			{
				findHandsTimer += Time.unscaledDeltaTime;
				if (findHandsTimer > 1.0f)
				{
					findHandsTimer = 0.0f;

					FindHands();
				}
			}
			*/

		//	if (activeBinding != null)
		//	{
		//		activeBinding.UpdateInput();

				// Now do edge detection and dispatch

			//	UpdateInput(HandType.Left, activeBinding.LeftHandIndex, activeBinding.LeftHand, ref wasLeftDown);
			//	UpdateInput(HandType.Right, activeBinding.RightHandIndex, activeBinding.RightHand, ref wasRightDown);

				// Clear manual input state

			//	triggerLeft = triggerRight = false;
		//	}
		}

			/*
		private void UpdateInput(HandType hand, int handIndex, GameObject handObj, ref bool wasButtonDown)
		{
			if (wandInputModule == null)
				return;
			
			if (handIndex != -1)
			{
				bool isDown = activeBinding.IsInputDown(hand);
				
				// Add manual input trigger
				if (hand == HandType.Left)
					isDown |= triggerLeft;
				else
					isDown |= triggerRight;
				
				int inputIndex = wandInputModule.GetHandToLocalIndex(handObj);
				
				if (isDown && !wasButtonDown)
					wandInputModule.LatchButtonDown(inputIndex);
				
				if (wasButtonDown && !isDown)
					wandInputModule.LatchButtonUp(inputIndex);
				
				wasButtonDown = isDown;
			}
		}
			*/

		public bool HasTarget(HandType targetHand)
		{
			if (targetHand == HandType.Left)
			{
				return leftStylus != null ? leftStylus.IsPointingAtPanel() : false;
			}
			else if (targetHand == HandType.Right)
			{
				return rightStylus != null ? rightStylus.IsPointingAtPanel() : false;
			}
			return false;
		}

		public void TriggerInput(HandType targetHand)
		{
			// No longer used
		}
	}
}
