using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public class LightManager : MonoBehaviour 
{
	[SerializeField] private CopLight[] listOfLights;
	[SerializeField] private Light[] floodLights;
	[SerializeField] private Light[] rotatingLights;
	[SerializeField] private GameObject lightParent;
	

	// Use this for initialization
	void Start () {
		
		listOfLights = GetComponentsInChildren<CopLight>();

		if (lightParent)
		{
			rotatingLights = lightParent.GetComponentsInChildren<Light>();
		}
		else
		{
			Debug.Log("light parent is missing.", this);
		}
		
		EnableLights();
	}

	[Button]
	public void EnableLights()
	{
		foreach (CopLight light in listOfLights)
		{
			if (light)
			{
				light.enabled = true; //turn off the light at start of game
				light.rotationEnabled = true;
			}else
			{
				Debug.Log("light is missing.", this);
			}
		}

		foreach (Light floodLight in floodLights)
		{
			if (floodLight)
			{
				floodLight.enabled = true;
			}
			else
			{
				Debug.Log("floodlight is missing.", this);
			}
		}
	}
	
	[Button]
	public void DisableLights()
	{
		foreach (CopLight light in listOfLights)
		{
			if (light)
			{
				light.enabled = false; //turn off the light at start of game
				light.rotationEnabled = false;
			}
			else
			{
				Debug.Log("light is missing.", this);
			}
		}
		
		foreach (Light floodLight in floodLights)
		{
			if (floodLight)
			{
				floodLight.enabled = false;
			}
			else
			{
				Debug.Log("floodlight is missing.", this);
			}
		}
	}

	public IEnumerator StartPoliceLights()
	{
		EnableLights();
		yield return null;
	}
}
