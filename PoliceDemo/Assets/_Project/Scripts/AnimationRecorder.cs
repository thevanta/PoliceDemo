using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRecorder : MonoBehaviour
{

    public float timeToRecord;
    
    // Start is called before the first frame update
    void Start()
    {
        StartRecording(timeToRecord);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartRecording(float timeToRecord)
    {
        StartCoroutine(RecordMovement(timeToRecord));
    }

    IEnumerator RecordMovement(float timeLimit)
    {
        yield return new WaitForSeconds(timeLimit);
    }
}
