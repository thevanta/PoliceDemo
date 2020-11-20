using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public class LightManager : MonoBehaviour {

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
	private AudioSource Sound;
	public AudioClip Siren1;
	public AudioClip Siren2;
	public AudioClip Horn;


	void Awake()
	{
		Sound = GetComponent<AudioSource> ();
	}
	

	// Use this for initialization
	void Start () {
		LightList = GetComponentsInChildren<CopLight>();
		lights = lightParent.GetComponentsInChildren<Light>();
		EnableLights();
	}

	[Button]
	public void EnableLights()
	{
		foreach (CopLight light in LightList)
		{
			light.enabled = true; //turn off the light at start of game
			light.rotationEnabled = true;
		}

		foreach (Light floodLight in floodLights)
		{
			floodLight.enabled = true;
		}
	}
	
	[Button]
	public void DisableLights()
	{
		foreach (CopLight light in LightList)
		{
			light.enabled = false; //turn off the light at start of game
			light.rotationEnabled = false;
		}
		
		foreach (Light floodLight in floodLights)
		{
			floodLight.enabled = false;
		}
	}

	public IEnumerator StartPoliceLights()
	{
		EnableLights();
		yield return null;
	}
}
