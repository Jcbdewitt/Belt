using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBelt : MonoBehaviour
{
    public bool moveObj;
    public GameObject belt;
    public Transform endpoint;
    public float speed;
    public float distanceToStop = 0.5f;

    void OnTriggerStay(Collider other)
    {
        //other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);

        if (moveObj == true)
        {
            /*
            var direction = Vector3.zero;
            if (Vector3.Distance(other.transform.position, endpoint.position) > distanceToStop)
            {
                Debug.Log("test");
                direction = endpoint.position;
                Debug.Log("direction is: " + direction);
                other.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up *speed, ForceMode.Force);
                Debug.Log(direction.normalized* speed);
            }
            */
            
            other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);
            
        }
        else
        {
            
            other.transform.position = other.transform.position;
                 
        }
    }
}
