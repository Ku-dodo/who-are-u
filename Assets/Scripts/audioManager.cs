using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class audioManager : MonoBehaviour
{
    public static audioManager instance;

    void Awake()
    {
        instance = this;
    }
    public AudioSource audioSource;
    public AudioClip bgmusic;
    public AudioClip flip;
    public AudioClip match;
    public AudioClip unmatch;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = bgmusic;
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
