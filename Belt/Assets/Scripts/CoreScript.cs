using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreScript : MonoBehaviour
{
    public int numberOfAttachedPiece;
    public bool Completed = false;

    // Update is called once per frame
    void Update()
    {
        if (numberOfAttachedPiece == 0 || numberOfAttachedPiece < 0)
        {
            Completed = true;
        }

        Debug.Log(numberOfAttachedPiece);
    }
}
