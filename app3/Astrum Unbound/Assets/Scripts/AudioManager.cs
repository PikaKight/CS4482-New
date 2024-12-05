using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public bool isLoop = true;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource.loop = isLoop;
        PlaySound();
    }

    public void PlaySound()
    {
        audioSource.Play();
    }

    public void StopSound()
    {
        audioSource.Stop();
    }
}
