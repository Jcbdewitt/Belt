using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActionScript : MonoBehaviour
{
    // a reference to the action
    public SteamVR_Action_Boolean GrabButton;
    // a reference to the hand
    public SteamVR_Input_Sources handType;

    public bool pressingGrab = false;

    void Start()
    {
        GrabButton.AddOnStateDownListener(TriggerDown, handType);
        GrabButton.AddOnStateUpListener(TriggerUp, handType);
    }
    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is up");

        pressingGrab = false;
        /*
        if (objectInRange != null)
        {
            Debug.Log("Should be grabbing");
            objectInHand = objectInRange;
            objectInRange.GetComponent<Transform>().parent = transform;
            grabbingSomething = true;
        }
        */
    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is down");

        pressingGrab = true;
        /*
        if (grabbingSomething && objectInHand != null)
        {
            objectInHand.GetComponent<Transform>().parent = null;
        }
        */
    }
}
