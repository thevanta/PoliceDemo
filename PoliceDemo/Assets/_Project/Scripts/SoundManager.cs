using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource introAudioSource;
    public AudioSource trafficAudioSource;
    
    public IEnumerator WaitForIntroAudio()
    {
        //TODO optimize if you can, use WaitForSeconds, or event
        while (introAudioSource.isPlaying)
        {
            yield return null;
        }
    }

    //TODO probably doesn't need to be a coroutine
    public IEnumerator PlayTrafficAudio()
    {
        trafficAudioSource.Play();
        yield return null;
    }
}
