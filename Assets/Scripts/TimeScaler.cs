using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TimeScaler : MonoBehaviour
{
    public float minTimeScale = 0.01f;
    public float maxTimeScale = 1f;
    public float TimeScalingModifier = 0.5f;
    public int timeScaleDecimalStep = 4;

    private float HeadVelocity;
    private float LeftHandVelocity;
    private float RightHandVelocity;

    private List<XRNodeState> nodeStates = new List<XRNodeState>();
    private XRNode headNode = XRNode.Head;
    private XRNode leftHandNode = XRNode.LeftHand;
    private XRNode rightHandNode = XRNode.RightHand;
    
    public void GetMovement()
    {
        InputTracking.GetNodeStates(nodeStates);
        foreach (XRNodeState nodeState in nodeStates)
        {
            if (nodeState.nodeType == headNode)
            {
                HeadVelocity = getVelocity(nodeState);
            }
            else if (nodeState.nodeType == leftHandNode)
            {
                LeftHandVelocity = getVelocity(nodeState);
            }
            else if (nodeState.nodeType == rightHandNode)
            {
                RightHandVelocity = getVelocity(nodeState);
            }
        }
    }

    public float getVelocity(XRNodeState node)
    {
        return node.TryGetAngularVelocity(out Vector3 nodeAngularVelocity) ? nodeAngularVelocity.magnitude : 0;
    }

    public float CalculateTimeScale(float headVelocity, float leftHandVelocity, float rightHandVelocity)
    {
        if(headVelocity > 1 / TimeScalingModifier || leftHandVelocity > 1 / TimeScalingModifier || rightHandVelocity > 1 / TimeScalingModifier)
        {
            return 1f;
        }
        else
        {
            float maxVelocity = Mathf.Max(headVelocity, leftHandVelocity, rightHandVelocity);
            return maxVelocity * TimeScalingModifier;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TimeScale", 1f, 1f); // run every 1 second, starting after 1 second
    }
    
    public void UpdateTimeScale(float newTimeScale)
    {
        newTimeScale = Mathf.Clamp(newTimeScale, minTimeScale, maxTimeScale);
        newTimeScale = (float)Math.Round(newTimeScale, timeScaleDecimalStep);
        Time.timeScale = newTimeScale;
    }

    // Update is called once per frame
    void Update()
    {
        GetMovement();
        float newTimeScale = CalculateTimeScale(HeadVelocity, LeftHandVelocity, RightHandVelocity);
        UpdateTimeScale(newTimeScale);
    }
}
