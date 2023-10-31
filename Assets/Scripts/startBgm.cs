using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startBgm : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip stbgmusic;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = stbgmusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
