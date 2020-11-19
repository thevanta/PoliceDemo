using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public ScreenFade screenFade;
    public SoundManager soundManager;
    public LightManager lightManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BeginGame());
    }

    private IEnumerator BeginGame()
    {
        yield return StartCoroutine(soundManager.WaitForIntroAudio());
        yield return StartCoroutine(screenFade.FadeImage(true));
        yield return StartCoroutine(lightManager.StartPoliceLights());
    }
}
