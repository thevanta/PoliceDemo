using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public class LightManager : MonoBehaviour 
{
	//TODO make public fields Serialized private fields	
	//FIX naming conventions, ie. private fields should be _camelCase
	public CopLight[] LightList;
	public Light[] floodLights;
	public float rotationsPerMinute = 50.0f;
	public float rotationsPerMinute2 = 70.0f;
	private float downTime, upTime, pressTime = 0;
	private float countDown = 0.2f;
	private bool horn = false;
	private float mode = 0;
	private int sirenMode = 0;
	private Light[] lights;
	public GameObject lightParent;
	
	private AudioSource Sound;		//TODO use descriptive name, ex) _lightAudioSource
	public AudioClip Siren1;		//TODO most likely names shouldn't be numbered, unless describing a sequence. Up to you
	public AudioClip Siren2;		//TODO use descriptive names, SirenCutOffAudioClip
	public AudioClip Horn;			//HornAudioClip


	void Awake()
	{
		Sound = GetComponent<AudioSource> ();
	}
	

	// Use this for initialization
	void Start () {
		//TODO add sanity checks, or debug messages
		LightList = GetComponentsInChildren<CopLight>();
		lights = lightParent.GetComponentsInChildren<Light>();
		EnableLights();
	}

	[Button]
	public void EnableLights()
	{
		foreach (CopLight light in LightList)
		{
			//TODO add sanity check
			//if (!light)
			light.enabled = true; //turn off the light at start of game
			light.rotationEnabled = true;
		}

		foreach (Light floodLight in floodLights)
		{
			//TODO add sanity check
			floodLight.enabled = true;
		}
	}
	
	[Button]
	public void DisableLights()
	{
		foreach (CopLight light in LightList)
		{
			//TODO add sanity check
			light.enabled = false; //turn off the light at start of game
			light.rotationEnabled = false;
		}
		
		foreach (Light floodLight in floodLights)
		{
			//TODO add sanity check
			floodLight.enabled = false;
		}
	}

	//TODO probably doesn't need to be a coroutine
	public IEnumerator StartPoliceLights()
	{
		EnableLights();
		yield return null;
	}
}
