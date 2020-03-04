using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartCubeScript : MonoBehaviour
{
    public bool restart = false;
    public bool invis = true;

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (!invis)
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
