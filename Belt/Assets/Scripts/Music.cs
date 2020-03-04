using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip intro;
    public AudioClip loop;

    void Start()
    {
        
        GetComponent<AudioSource>().loop = true;
        StartCoroutine(playMusic());
        
    }

    IEnumerator playMusic()
    {
        GetComponent<AudioSource>().clip = intro;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        GetComponent<AudioSource>().clip = loop;
        GetComponent<AudioSource>().Play();
    }

}
