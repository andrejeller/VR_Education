using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 'Shadow' camera rig based entirely on UnityEngine.XR interface
 * Keeps track of world-space position and rotation of hmd/left hand/right hand without needing any external plugins (eg. SteamVR or Rift)
 */
public class XrNodeRig : MonoBehaviour
{
	public Transform headTransform;
	public Transform leftHandTransform;
	public Transform rightHandTransform;

	// Internal State

	// The current vr camera
	// We cache this between frames and only refetch it if it's been deleted or is no longer valid
	private Camera vrCamera;

	void Update ()
	{
		// We know the VR camera's world position/rotation and it's locally tracked position/rotation
		// Using these we can work out the tracking space's origin and set ourselves to that
		// 
		// Then we can easily set the hand transforms as they're just relative to the ourselves/tracking origin

		if (!IsVrCameraValid())
			FindVrCamera();
		
		if (IsVrCameraValid())
		{
			// Query all of the vr node states
			List<UnityEngine.XR.XRNodeState> states = new List<UnityEngine.XR.XRNodeState>();
			UnityEngine.XR.InputTracking.GetNodeStates(states);

			// Find and process the HMD node first
			foreach (UnityEngine.XR.XRNodeState state in states)
			{
				if (state.nodeType == UnityEngine.XR.XRNode.Head)
				{
					// First align ourselves with the camera rig's rotation
					// Note we also zero our position to make the next step easier
					Quaternion trackedRotation;
					state.TryGetRotation(out trackedRotation);
					Quaternion rigRotation = vrCamera.transform.rotation * Quaternion.Inverse(trackedRotation);
					this.transform.position = Vector3.zero;
					this.transform.rotation = rigRotation;

					// Now we know the rig rotation, figure out what world-space offset we need to align a local camera offset with the actual world camera position
					Vector3 trackedPosition;
					state.TryGetPosition(out trackedPosition);
					Vector3 rigPosition = vrCamera.transform.position - this.transform.TransformPoint(trackedPosition);
					this.transform.position = rigPosition;
				}
				else if (state.nodeType == UnityEngine.XR.XRNode.LeftHand)
				{
					// Apply the local position/rotation to the left hand transform
					Sync(state, leftHandTransform);
				}
				else if (state.nodeType == UnityEngine.XR.XRNode.RightHand)
				{
					// Apply the local position/rotation to the right hand transform
					Sync(state, rightHandTransform);
				}
			}
		}
	}

	private void Sync(UnityEngine.XR.XRNodeState node, Transform destTransform)
	{
		Vector3 position;
		if (node.TryGetPosition(out position))
		{
			destTransform.localPosition = position;
		}
		Quaternion rotation;
		if (node.TryGetRotation(out rotation))
		{
			destTransform.localRotation = rotation;
		}

		destTransform.gameObject.SetActive(node.tracked);
	}

	private bool IsVrCameraValid()
	{
		return vrCamera != null && vrCamera.isActiveAndEnabled && vrCamera.stereoTargetEye == StereoTargetEyeMask.Both;
	}

	private void FindVrCamera()
	{
		foreach (Camera cam in Camera.allCameras)
		{
			if (cam != null && cam.isActiveAndEnabled && cam.stereoTargetEye == StereoTargetEyeMask.Both)
			{
				vrCamera = cam;
				break;
			}
		}
	}
}
