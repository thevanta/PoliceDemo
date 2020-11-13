using System;
using UnityEngine;
using System.Collections;




public class CopLight : MonoBehaviour {

	public float Offset;
	public bool flickering = false;
	public bool flicker = false;
	public float delayFlicker = 0;
	public float speedFlicker = 0.4f;
	public float rotationsPerMinute = 50f;
	public float rotationSpeedModifier = 1f;
	public bool rotationEnabled = false;
	public Light myLight;

	private void Awake()
	{
		myLight = GetComponent<Light>();
	}

	void Start()
	{
		transform.Rotate(0, Offset, 0);
		StartCoroutine(Flashing());
	}

	private void OnEnable()
	{
		myLight.enabled = true;
	}
	
	private void OnDisable()
	{
		myLight.enabled = false;
	}

	void Update ()
	{
		if (rotationEnabled)
		{
			transform.Rotate(0, 6.0f * rotationsPerMinute * rotationSpeedModifier * Time.deltaTime, 0);
		}
	}
	
	
	IEnumerator Flashing ()
	{
		if (flickering == true) {
			yield return new WaitForSeconds (delayFlicker);
			while (true) 
			{
				yield return new WaitForSeconds (speedFlicker);
				myLight.intensity = 0;
				yield return new WaitForSeconds (speedFlicker);
				myLight.intensity = 3;
				Debug.Log ("Flicker");
			}
		}
	}
}





