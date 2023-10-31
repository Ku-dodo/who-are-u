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
    public AudioClip PlayClickSound;
    public AudioClip PlayMatchedSound;
    public AudioClip PlayUnMatchedSound;

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
    public void PCSPaly()
    {
        audioSource.PlayOneShot(PlayClickSound);
    }
    public void PMSPaly()
    {
        audioSource.PlayOneShot(PlayMatchedSound);
    }
    public void PUMSPaly()
    {
        audioSource.PlayOneShot(PlayUnMatchedSound);
    }
}
