using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InteractableScript : MonoBehaviour
{
    [HideInInspector]
    public HandScript m_ActiveHand = null;
}
