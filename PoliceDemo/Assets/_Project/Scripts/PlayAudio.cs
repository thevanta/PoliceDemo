using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogoDigital.Lipsync;

public class PlayAudio : MonoBehaviour
{
    public LipSync Player;
    public LipSyncData Clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            Player.Play(Clip);
        }
    }
}
