using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapColliderScript : MonoBehaviour
{
    public GameObject attachedPiece;
    public Rigidbody SnapPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == attachedPiece)
        {
            attachedPiece.gameObject.AddComponent<FixedJoint>().connectedBody = SnapPoint;
        }
    }
}
