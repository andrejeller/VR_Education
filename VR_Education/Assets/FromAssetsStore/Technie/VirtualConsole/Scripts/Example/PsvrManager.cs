using UnityEngine;
#if UNITY_PS4
using UnityEngine.VR;
#endif

using System.Collections;
using System.Collections.Generic;

namespace Technie.VirtualConsole
{
	public class PsvrManager : MonoBehaviour 
	{
		public float renderScale = 1.4f; // 1.4 is Sony's recommended scale for PlayStation VR
		public bool showDeviceView = false;

		private static PsvrManager _instance;

	#if UNITY_PS4 && !UNITY_EDITOR
		
		public static PsvrManager instance
		{
			get
			{
				if(_instance == null)
				{
					_instance = GameObject.FindObjectOfType<PsvrManager>();
					DontDestroyOnLoad(_instance.gameObject);
				}
				
				return _instance;
			}
		}
		
		void Awake() 
		{
			Debug.Log("PsvrManager.Awake");

			if(_instance == null)
			{
				_instance = this;
				DontDestroyOnLoad(this);
			}
			else if(this != _instance)
			{
				// There can be only one!
				Destroy(this.gameObject);
			}

			StartCoroutine( SetupVR() );
		}

		void Update()
		{
			// Reset the headset tracking using the 'Options' button
			if(Input.GetKeyDown(KeyCode.JoystickButton7))
			{
				Debug.Log("PsvrManager.Update - button 7 pressed so recentering...");
				InputTracking.Recenter();
			}
		}
		
		IEnumerator SetupVR()
		{
			Debug.Log("PsvrManager.SetupVR");

	#if UNITY_5_4_OR_NEWER
			VRSettings.LoadDeviceByName(VrDeviceNames.PlayStationVr);
	#else
			VRSettings.loadedDevice = VRDeviceType.Morpheus;
	#endif

			yield return true;
			VRSettings.enabled = true;
			VRSettings.renderScale = renderScale;
			VRSettings.showDeviceView = showDeviceView;
		}
		
	#endif
	}
} // namespace Technie.VirtualConsole
