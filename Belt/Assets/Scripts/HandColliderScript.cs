using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandColliderScript : MonoBehaviour
{
    public GameObject ConnectedHand;
    private ActionScript actionScript;

    private GameObject Object;

    public bool objectInHand = false;
    public bool objectInRange = false;

    private void Start()
    {
        actionScript = ConnectedHand.GetComponent<ActionScript>();
    }

    private void Update()
    {
        if ((objectInRange || objectInHand) && actionScript.pressingGrab)
        {
            if (!objectInHand)
            {
                Object.transform.parent = gameObject.transform.parent;
            }

            if (Object.GetComponent<Rigidbody>() != null)
            {
                Object.GetComponent<Rigidbody>().useGravity = false;
                Object.GetComponent<Rigidbody>().isKinematic = true;
            }

            if (Object.GetComponent<PartScript>() != null)
            {
                Object.GetComponent<PartScript>().grabbedByHand = true;
            }

            if (Object.GetComponent<HammerScript>() != null)
            {
                Object.GetComponent<HammerScript>().InHand = true;
            }

            objectInHand = true;
        } else
        {
            if (objectInHand)
            {
                objectInHand = false;

                if (Object != null)
                {
                    Object.transform.parent = null;

                    if (Object.GetComponent<Rigidbody>() != null)
                    {
                        Object.GetComponent<Rigidbody>().useGravity = true;
                        Object.GetComponent<Rigidbody>().isKinematic = false;
                    }

                    if (Object.GetComponent<PartScript>() != null)
                    {
                        Object.GetComponent<PartScript>().grabbedByHand = false;
                    }

                    if (Object.GetComponent<HammerScript>() != null)
                    {
                        Object.GetComponent<HammerScript>().InHand = false;
                    }

                    Object = null;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "interactable" && !objectInHand)
        {
            //Debug.Log("Entering Object");
            objectInRange = true;
            Object = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "interactable" && !objectInHand)
        {
           // Debug.Log("exiting Object");
            objectInRange = false;
            Object = null;
        }
    }
}
