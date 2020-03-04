using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailScript : MonoBehaviour
{
    public bool hit = false;
    public bool UpRightNail = false;
    public bool FullyNailedIn = false;
    public int hitsUntilHammered = 3;
    public float movementAmount = 0.02f;

    private void Awake()
    {
        Vector3 UnnailedLocation = gameObject.transform.position;
        
        if (UpRightNail)
        {
            UnnailedLocation.y += movementAmount * hitsUntilHammered;
        } else
        {
            UnnailedLocation.y -= movementAmount * hitsUntilHammered;
        }

        transform.position = UnnailedLocation;
    }

    private void Update()
    {
        if (hit && hitsUntilHammered > 0)
        {
            Vector3 NewNailedLocation = gameObject.transform.position;
            
            if (UpRightNail)
            {
                NewNailedLocation.y -= movementAmount;
            } else {
                NewNailedLocation.y += movementAmount;
            }

            hitsUntilHammered -= 1;

            transform.position = NewNailedLocation;

            hit = false;
        } else if (hitsUntilHammered < 0 || hitsUntilHammered == 0)
        {
            FullyNailedIn = true;
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
