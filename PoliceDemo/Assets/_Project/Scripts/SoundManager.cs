using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource introAudioSource;
    [SerializeField] private AudioSource trafficAudioSource;
    [SerializeField] private float waitDelay;
    
    
    public IEnumerator WaitForIntroAudio()
    {
        while (introAudioSource.isPlaying)
        {
            yield return new WaitForSeconds(waitDelay);
        }
    }

    public IEnumerator PlayTrafficAudio()
    {
        trafficAudioSource.Play();
        yield return null;
    }
}
