using System.Collections;

using UnityEngine;
#if UNITY_PS4
using UnityEngine.PS4;
using UnityEngine.PS4.VR;
#endif

namespace Technie.VirtualConsole
{
	/*
	public class PsVrBinding : ApiBinding
	{
		private GameObject leftHand;
		private GameObject rightHand;

		private int m_primaryHandle = ApiBinding.INVALID_HAND_INDEX;
		private int m_secondaryHandle = ApiBinding.INVALID_HAND_INDEX;

		private bool isLeftButtonDown;
		private bool isRightButtonDown;

	#if UNITY_PS4
//		private int m_primaryHandle = -1;
//		private int m_secondaryHandle = -1;
//		private Vector3 primaryPosition = Vector3.zero;
//		private Quaternion primaryOrientation = Quaternion.identity;
//		private Vector3 secondaryPosition = Vector3.zero;
//		private Quaternion secondaryOrientation = Quaternion.identity;
	#endif

		// Exposed Properties

		public override int LeftHandIndex
		{
			get { return m_primaryHandle; }
		}
		public override int RightHandIndex
		{
			get { return m_secondaryHandle; }
		}

		public override GameObject LeftHand
		{
			get { return leftHand; }
		}
		public override GameObject RightHand
		{
			get { return rightHand; }
		}

		void OnEnable()
		{
			leftHand = new GameObject ("PsVr Left Hand");
			leftHand.transform.SetParent (this.transform.parent, false);
			leftHand.transform.localPosition = Vector3.zero;
			leftHand.transform.localRotation = Quaternion.identity;
			leftHand.transform.localScale = Vector3.one;

			rightHand = new GameObject ("PsVr Right Hand");
			rightHand.transform.SetParent (this.transform.parent, false);
			rightHand.transform.localPosition = Vector3.zero;
			rightHand.transform.localRotation = Quaternion.identity;
			rightHand.transform.localScale = Vector3.one;

			m_primaryHandle = ApiBinding.INVALID_HAND_INDEX;
			m_secondaryHandle = ApiBinding.INVALID_HAND_INDEX;
		}

		void OnDisable()
		{
			GameObject.Destroy (leftHand);
			GameObject.Destroy (rightHand);

			leftHand = rightHand = null;
		}

		private bool IsPsVrAvailable()
		{
#if UNITY_PS4 && !UNITY_EDITOR
	#if UNITY_5_4_OR_NEWER
			bool isPsVr = UnityEngine.VR.VRSettings.loadedDeviceName == VrDeviceNames.PlayStationVr && UnityEngine.VR.VRDevice.isPresent;
	#else
			// TODO: Fixme.
		//	bool isPsVr = VRSettings.loadedDevice == VRDeviceType.Morpheus;
			bool isPsVr = true;
	#endif
			return isPsVr;
#else
			return false;
#endif
		}

		public override int FindHands()
		{
			if (!VirtualConsole.Instance.usePsVr)
				return 0;

			if (!IsPsVrAvailable ())
				return 0;

			RegisterMoveControllers ();

			if (m_secondaryHandle > 0)
				return 2;
			else if (m_primaryHandle > 0)
				return 1;
			else
				return 0;
		}


		void RegisterMoveControllers()
		{
#if UNITY_PS4
			Debug.Log ("PsVrBinding.RegisterMoveControllers");

			int [] primaryHandles = new int[1];
			int [] secondaryHandles = new int[1];
			PS4Input.MoveGetUsersMoveHandles(1, primaryHandles, secondaryHandles);
			m_primaryHandle = primaryHandles[0];
			m_secondaryHandle = secondaryHandles[0];
			
			Tracker.RegisterTrackedDevice(PlayStationVRTrackedDevice.DeviceMove, primaryHandles[0], PlayStationVRTrackingType.Absolute, PlayStationVRTrackerUsage.Default);

			Tracker.RegisterTrackedDevice(PlayStationVRTrackedDevice.DeviceMove, secondaryHandles[0], PlayStationVRTrackingType.Absolute, PlayStationVRTrackerUsage.Default);
#endif
		}
		
		// Remove the registered devices from tracking and reset the transform
		void UnregisterMoveControllers()
		{
#if UNITY_PS4
			Debug.Log ("PsVrBinding.UnregisterMoveControllers");

			// TODO: Seems overly complicated, can this be simpler?

			int[] primaryHandles = new int[1];
			int[] secondaryHandles = new int[1];
			PS4Input.MoveGetUsersMoveHandles(1, primaryHandles, secondaryHandles);
			m_primaryHandle = -1;
			m_secondaryHandle = -1;

			leftHand.transform.SetParent(Camera.main.transform.parent, false);
			rightHand.transform.SetParent(Camera.main.transform.parent, false);
			
			Tracker.UnregisterTrackedDevice(primaryHandles[0]);
			leftHand.transform.localPosition = Vector3.zero;
			leftHand.transform.localRotation = Quaternion.identity;

			Tracker.UnregisterTrackedDevice(secondaryHandles[0]);
			rightHand.transform.localPosition = Vector3.zero;
			rightHand.transform.localRotation = Quaternion.identity;
#endif
		}


		public override void UpdateInput()
		{
			if (m_primaryHandle != -1)
			{

			}

			if (m_secondaryHandle != -1)
			{

			}

			// TEMP PLACEHOLDER
			isLeftButtonDown = Input.GetButton ("joystick button 0");
			isRightButtonDown = Input.GetButton ("joystick button 1");
		}

		public override bool IsInputDown(HandType hand)
		{
			if (hand == HandType.Left)
				return isLeftButtonDown;
			else
				return isRightButtonDown;
		}

#if UNITY_PS4
		void Update()
		{
		//	if (IsPsVrAvailable() && UnityEngine.VR.VRDevice.isPresent)
			if (IsPsVrAvailable())
			{
				// Perform tracking for the primary controller, if we've got a handle
				if (m_primaryHandle >= 0)
				{
			//		Debug.Log ("PsVrBinding do left hand tracking");

					Vector3 primaryPosition = Vector3.zero;
					Quaternion primaryOrientation = Quaternion.identity;

					if ( Tracker.GetTrackedDevicePosition(m_primaryHandle, out primaryPosition) == PlayStationVRResult.Ok )
						leftHand.transform.localPosition = primaryPosition;
					
					if ( Tracker.GetTrackedDeviceOrientation(m_primaryHandle, out primaryOrientation) == PlayStationVRResult.Ok )
						leftHand.transform.localRotation = primaryOrientation;
				}
				
				// Perform tracking for the secondary controller, if we've got a handle
				if (m_secondaryHandle >= 0)
				{
					Vector3 secondaryPosition = Vector3.zero;
					Quaternion secondaryOrientation = Quaternion.identity;

					if ( Tracker.GetTrackedDevicePosition(m_secondaryHandle, out secondaryPosition) == PlayStationVRResult.Ok )
						rightHand.transform.localPosition = secondaryPosition;
					
					if ( Tracker.GetTrackedDeviceOrientation(m_secondaryHandle, out secondaryOrientation) == PlayStationVRResult.Ok )
						rightHand.transform.localRotation = secondaryOrientation;
				}
			}
		}
#endif // UNITY_PS4

	}
	*/
}
