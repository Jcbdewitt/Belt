using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartScript : MonoBehaviour
{
    public GameObject ConnectedNail;
    private FixedJoint fixedJoint;
    private NailScript connectedNailScript;
    public GameObject Core;
    public bool finishedPart = false;
    public bool grabbedByHand = false;
    public bool leavingCore = false;
    public bool stuckOnCore = false;
    bool OnlyOnce = true;

    private void Start()
    {
        connectedNailScript = ConnectedNail.GetComponent<NailScript>();
        fixedJoint = GetComponent<FixedJoint>();
    }

    private void Update()
    {
        if (!connectedNailScript.FullyNailedIn)
        {
            
            if (stuckOnCore)
            {
                ConnectedNail.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                ConnectedNail.GetComponent<MeshRenderer>().enabled = false;
            }
            
            if (grabbedByHand && !finishedPart)
            {
                stuckOnCore = false;
                //gameObject.layer = LayerMask.NameToLayer("Piece");
                RemoveFixedJoint();
            }
        } else
        {
            if (OnlyOnce)
            {
                Debug.Log("completed");
                Core.GetComponent<CoreScript>().numberOfAttachedPiece -= 1;
                OnlyOnce = false;
                finishedPart = true;
                //transform.gameObject.tag = "nonInteractable";
                gameObject.layer = LayerMask.NameToLayer("AttachedPiece");
                RemoveFixedJoint();
                gameObject.AddComponent<FixedJoint>().connectedBody = Core.GetComponent<Rigidbody>();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!finishedPart && !grabbedByHand)
        {
            if (collision.gameObject.GetComponent<CoreScript>() != null)
            {
                Debug.Log("hit the core");
                Rigidbody coreRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                //gameObject.layer = LayerMask.NameToLayer("AttachedPiece");
                gameObject.AddComponent<FixedJoint>().connectedBody = coreRigidbody;
                stuckOnCore = true;
            }
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!finishedPart && !grabbedByHand)
        {
            if (collision.gameObject.GetComponent<CoreScript>() != null)
            {
                Debug.Log("left the core");
                //gameObject.layer = LayerMask.NameToLayer("Piece");
                RemoveFixedJoint();
                stuckOnCore = false;
            }
        }
    }

    private void RemoveFixedJoint()
    {
        if (GetComponent<FixedJoint>() != null)
        {
            Destroy(GetComponent<FixedJoint>());
        }
    }
}
