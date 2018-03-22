//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: For controlling in-game objects with tracked devices.
//
//=============================================================================

using UnityEngine;
using Valve.VR;
using System.Collections;

public class SteamVR_TrackedObjectCustom : MonoBehaviour
{
	public enum EIndex
	{
		None = -1,
		Hmd = (int)OpenVR.k_unTrackedDeviceIndex_Hmd,
		Device1,
		Device2,
		Device3,
		Device4,
		Device5,
		Device6,
		Device7,
		Device8,
		Device9,
		Device10,
		Device11,
		Device12,
		Device13,
		Device14,
		Device15
	}

	public EIndex index;

	[Tooltip("If not set, relative to parent")]
	public Transform origin;

    public bool isValid { get; private set; }

    // Custom
    private Transform m_targetTransform;

    private void OnNewPoses(TrackedDevicePose_t[] poses)
	{
		if (index == EIndex.None)
			return;

		var i = (int)index;

        isValid = false;
		if (poses.Length <= i)
			return;

		if (!poses[i].bDeviceIsConnected)
			return;

		if (!poses[i].bPoseIsValid)
			return;

        isValid = true;

		var pose = new SteamVR_Utils.RigidTransform(poses[i].mDeviceToAbsoluteTracking);

        // Custom
        if (origin != null)
        {
            m_targetTransform.position = origin.transform.TransformPoint(pose.pos);
            m_targetTransform.rotation = origin.rotation * pose.rot;
        }
        else
        {
            m_targetTransform.localPosition = pose.pos;
            m_targetTransform.localRotation = pose.rot;
        }
        StartCoroutine(LaggyFollow(m_targetTransform.position, m_targetTransform.rotation, GeneralManager.LATENCY_OFFSET));

        /*
        if (origin != null)
		{
			transform.position = origin.transform.TransformPoint(pose.pos);
			transform.rotation = origin.rotation * pose.rot;
		}
		else
		{
			transform.localPosition = pose.pos;
			transform.localRotation = pose.rot;
		}
        */
    }

    // Custom
    private IEnumerator LaggyFollow(Vector3 pos, Quaternion rot, float time)
    {
        yield return new WaitForSeconds(time);
        transform.position = pos;
        transform.rotation = rot;
    }

    SteamVR_Events.Action newPosesAction;

	SteamVR_TrackedObjectCustom()
	{
		newPosesAction = SteamVR_Events.NewPosesAction(OnNewPoses);
	}

	void OnEnable()
	{
		var render = SteamVR_Render.instance;
		if (render == null)
		{
			enabled = false;
			return;
		}

		newPosesAction.enabled = true;
	}

	void OnDisable()
	{
		newPosesAction.enabled = false;
		isValid = false;
	}

	public void SetDeviceIndex(int index)
	{
		if (System.Enum.IsDefined(typeof(EIndex), index))
			this.index = (EIndex)index;
	}
}

