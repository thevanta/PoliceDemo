using System;
using UnityEngine;
using System.Collections;




public class CopLight : MonoBehaviour 
{
	//TODO make sure name code style casing is uniform
	//TODO make public fields Serialized private fields	
	[SerializeField] private float Offset;	//like this
	
	public bool flickering = false;
	public bool flicker = false;	//TODO not being used
	public float delayFlicker = 0;
	public float speedFlicker = 0.4f;
	public float rotationsPerMinute = 50f;
	public float rotationSpeedModifier = 1f;
	public bool rotationEnabled = false;
	
	public Light myLight;	//TODO light is public and can be set, but is also automatically assigned on awake

	//TODO use cached transformed
	//private Transform thisTransform;
	
	
	private void Awake()
	{
		//TODO add sanity check, to make sure you found Light
		myLight = GetComponent<Light>();	//TODO if you are getting on awake, make myLight private
		/*
		 * if (myLight == null)
		{
			Debug.Log("myLight is null, attempting to get on gameObject.", this);
			myLight = GetComponent<Light>();	//TODO if you are getting on awake, make myLight private
			if (myLight == null)
			{
				Debug.Log("myLight is null.", this);
				//Add light component
				// or error
			}
		}
		 */

		//TODO cache transform
		//thisTransform = transform;
	}

	void Start()
	{
		transform.Rotate(0, Offset, 0);		//TODO cache the transform
		StartCoroutine(Flashing());
	}

	private void OnEnable()
	{	
		//TODO null check
		myLight.enabled = true;
	}
	
	private void OnDisable()
	{
		//TODO null check
		myLight.enabled = false;
	}

	void Update ()
	{
		if (rotationEnabled)
		{
			//TODO don't hardcode yAngle
			transform.Rotate(0, 6.0f * rotationsPerMinute * rotationSpeedModifier * Time.deltaTime, 0);		//TODO use cached transform
		}
	}
	
	private IEnumerator Flashing ()
	{
		if (flickering == true) {
			yield return new WaitForSeconds (delayFlicker);
			while (true)
			{
				yield return new WaitForSeconds (speedFlicker);
				myLight.intensity = 0;
				yield return new WaitForSeconds (speedFlicker);
				myLight.intensity = 3;		//TODO don't hardcode, change to constant
				Debug.Log ("Flicker");
			}
		}
	}
}





