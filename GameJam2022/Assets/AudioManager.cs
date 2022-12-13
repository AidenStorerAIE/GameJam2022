using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> clips;
    public AudioSource BGM;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        PlayBGM();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDraw()
    {
        audioSource.clip = clips[0];
        audioSource.Play();
        audioSource.loop=true;
    }
    public void PlayClick()
    {
        audioSource.clip = clips[1];
        audioSource.Play();
    }

    public void PlayBGM()
    {
        BGM.clip = clips[2];
        BGM.Play();
        BGM.loop = true;
    }


    public void PlayDeath()
    {
        audioSource.clip = clips[3];
        audioSource.Play();
    }

    public void PlayUI()
    {
        audioSource.clip = clips[7];
        audioSource.Play();
    }

    internal void Cancel()
    {
        audioSource.loop = false;
        audioSource.Stop();
    }
}
