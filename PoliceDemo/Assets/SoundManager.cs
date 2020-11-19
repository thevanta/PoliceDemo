using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource introAudioSource;
    public AudioSource trafficAudioSource;
    
    public IEnumerator WaitForIntroAudio()
    {
        while (introAudioSource.isPlaying)
        {
            yield return null;
        }
    }

    public IEnumerator PlayTrafficAudio()
    {
        trafficAudioSource.Play();
        yield return null;
    }
}
