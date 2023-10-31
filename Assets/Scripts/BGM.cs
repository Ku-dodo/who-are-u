using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM instance;
    public AudioSource audioSource;
    public AudioClip bgmusic;

    //BMG 재생속도(pitch) 변수
    float audioSpeed;

    void Awake()
    {
        instance = this;
        audioSpeed = GetComponent<AudioSource>().pitch = 1.0f;
    }
    void Start()
    {
        audioSource.clip = bgmusic;
        audioSource.Play();
    }

    /*void Update()
    {
        
    }*/
    public void SpeedUp(int type)
    {
        switch (type)
        {
            case 0:
                StartCoroutine(IsAudioSpeedUp(speed: 0f));
                break;
            case 1:
                StartCoroutine(IsAudioSpeedUp(speed: 1.1f));
                break;
            case 2:
                StartCoroutine(IsAudioSpeedUp(speed: 1.2f));
                break;
        }
    }
    IEnumerator IsAudioSpeedUp(float speed)
    {
        /*Debug.Log("bmgSpeedUp");*/
        audioSpeed = GetComponent<AudioSource>().pitch = speed;

        yield break;
    }
}
