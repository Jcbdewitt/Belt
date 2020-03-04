using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnnerScript : MonoBehaviour
{
    public GameObject Tray;

    public bool SpawnTray = true;
    
    // Update is called once per frame
    void Update()
    {
        if (SpawnTray)
        {
            SpawnTray = false;

            Instantiate(Tray, transform.position, transform.rotation);
        }
    }
}
