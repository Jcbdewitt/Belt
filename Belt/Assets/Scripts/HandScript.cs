using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HandScript : MonoBehaviour
{
    public ActionScript actionScript;

    private SteamVR_Behaviour_Pose m_pose = null;
    private FixedJoint m_Joint = null;

    private InteractableScript m_CurrentInteractable = null;
    private List<InteractableScript> m_ContactInteractables = new List<InteractableScript>();

    public bool HoldingSomething = false;

    private void Awake()
    {
        m_pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();
    }
    
    private void Update()
    {
        
        if (actionScript.pressingGrab)
        {
            if (!HoldingSomething)
            {
                Pickup();
            }
            
        }

        if (!actionScript.pressingGrab)
        {
            if (HoldingSomething)
            {
                Drop();
            }
            
        }
    }
        private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;

        m_ContactInteractables.Add(other.gameObject.GetComponent<InteractableScript>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;

        m_ContactInteractables.Remove(other.gameObject.GetComponent<InteractableScript>());
    }

    public void Pickup()
    {
        m_CurrentInteractable = GetNearestInteractable();

        if (!m_CurrentInteractable)
            return;

        HoldingSomething = true;
        if (m_CurrentInteractable.m_ActiveHand)
            m_CurrentInteractable.m_ActiveHand.Drop();

        if (m_CurrentInteractable.gameObject.GetComponent<PartScript>() != null)
        {
            m_CurrentInteractable.gameObject.GetComponent<PartScript>().grabbedByHand = true;
        }

        if (m_CurrentInteractable.gameObject.GetComponent<HammerScript>() != null)
        {
            m_CurrentInteractable.gameObject.GetComponent<HammerScript>().InHand = true;
        }

        if (m_CurrentInteractable.gameObject.GetComponent<RestartCubeScript>() != null)
        {
            m_CurrentInteractable.gameObject.GetComponent<RestartCubeScript>().restart = true;
        }

        m_CurrentInteractable.transform.position = transform.position;

        Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        m_Joint.connectedBody = targetBody;

        m_CurrentInteractable.m_ActiveHand = this;
    }

    public void Drop()
    {
        if (!m_CurrentInteractable)
            return;

        HoldingSomething = false;
        Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = m_pose.GetVelocity();
        targetBody.angularVelocity = m_pose.GetAngularVelocity();

        m_Joint.connectedBody = null;

        if (m_CurrentInteractable.gameObject.GetComponent<PartScript>() != null)
        {
            m_CurrentInteractable.gameObject.GetComponent<PartScript>().grabbedByHand = false;
        }

        if (m_CurrentInteractable.gameObject.GetComponent<HammerScript>() != null)
        {
            m_CurrentInteractable.gameObject.GetComponent<HammerScript>().InHand = false;
        }

        m_CurrentInteractable.m_ActiveHand = null;
        m_CurrentInteractable = null;
    }

    private InteractableScript GetNearestInteractable()
    {
        InteractableScript nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach(InteractableScript interactable in m_ContactInteractables)
        {
            distance = (interactable.transform.position - transform.position).sqrMagnitude;
            
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }
        }

        return nearest;
    }
}
