using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ExitScript exitScript;
    public SpawnnerScript spawnner;
    public GameObject restartCube;
    public GameObject StartScreen;
    public GameObject EndScreen;
    public GameObject Bear;
    public GameObject Rabbit;
    public GameObject Horse;
    public GameObject Dino;
    public bool endCheck;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        restartCube.GetComponent<MeshRenderer>().enabled = false;
        restartCube.GetComponent<RestartCubeScript>().invis = true;
        EndScreen.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (exitScript.spawnNext)
        {
            exitScript.spawnNext = false;
            int nextPiece = RandNum(1,3);

            
            if (nextPiece == 1) {
                spawnner.Tray = Rabbit;
            } else if (nextPiece == 2) {
                spawnner.Tray = Dino;
            } 

            spawnner.SpawnTray = true;
        } else if (exitScript.messedUpToy)
        {
            gameOver = true;
            Debug.Log("GameOVer");
            StartScreen.GetComponent<MeshRenderer>().enabled = false;
            restartCube.GetComponent<MeshRenderer>().enabled = true;
            restartCube.GetComponent<RestartCubeScript>().invis = false;
            EndScreen.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    public int RandNum(int min, int max)
    {
        System.Random random = new System.Random();
        int test = random.Next(min, max);
        Debug.Log(test);
        return test;
    }
}
