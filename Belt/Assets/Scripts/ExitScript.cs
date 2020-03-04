using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public bool spawnNext = false;
    public bool messedUpToy = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CoreScript>()!= null)
        {
            Debug.Log("hit exit");
            if (other.gameObject.GetComponent<CoreScript>().Completed)
            {
                spawnNext = true;
                Destroy(other.gameObject.transform.parent.gameObject);
            } else
            {
                messedUpToy = true;
                Destroy(other.gameObject.transform.parent.gameObject);
            }
            
        }
    }
}
