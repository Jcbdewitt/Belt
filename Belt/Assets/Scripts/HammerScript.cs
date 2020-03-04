using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public bool InHand = false;
    public bool HammerHitNail = false;

    private void Update()
    {
        if (InHand)
        {
            GetComponent<MeshCollider>().isTrigger = true;
        } else
        {
            GetComponent<MeshCollider>().isTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        if (other.gameObject.GetComponent<NailScript>() != null)
        {
            Debug.Log("hit");
            other.gameObject.GetComponent<NailScript>().hit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
