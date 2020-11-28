using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Sirenix.OdinInspector;

public class ScreenFade : MonoBehaviour {
 
    // the image you want to fade, assign in inspector
    public RawImage image;

    [Button]
    public void FadeToOpaque()
    {
        StartCoroutine(FadeImage(false));
    }
    
    [Button]
    public void FadeToTransparent()
    {
        StartCoroutine(FadeImage(true));
    }
    
    public IEnumerator FadeImage(bool fadeToTransparent)
    {
        // fade from opaque to transparent
        if (fadeToTransparent)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                image.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                image.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
