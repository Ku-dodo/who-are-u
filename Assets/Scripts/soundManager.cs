using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager I;
    void Awake()
    {
        I = this;
    }
    public AudioSource audioSource;
    public AudioClip flip;
    public AudioClip match;
    public AudioClip unmatch;
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
    public void flipPlay()
    {
        audioSource.PlayOneShot(flip);
    }
    public void matchPlay()
    {
        audioSource.PlayOneShot(match);
    }
    public void unmatchPlay()
    {
        audioSource.PlayOneShot(unmatch);
    }
}
