using System;
using UnityEngine;
using System.Collections;




public class CopLight : MonoBehaviour 
{
	public bool rotationEnabled = false;

	[SerializeField] private float offset;
	[SerializeField] private float rotationsPerMinute = 50f;
	[SerializeField] private float rotationSpeedModifier = 1f;
	[SerializeField] private float yAngle = 6.0f;
	
	private Light _myLight;	

	private void Awake()
	{
		_myLight = GetComponent<Light>();	
		
		if (_myLight == null)
		{
			Debug.Log("myLight is null, attempting to get on gameObject.", this);
			_myLight = GetComponent<Light>();	
			if (_myLight == null)
			{
				Debug.Log("myLight is null.", this);
				gameObject.AddComponent<Light>();
			}
		}
	}

	void Start()
	{
		transform.Rotate(0, offset, 0);	
	}

	private void OnEnable()
	{	
		if (_myLight)
		{
			_myLight.enabled = true;
		}
		else
		{
			Debug.Log("Unable to turn on lights. Light is null.", this);
		}
	}
	
	private void OnDisable()
	{
		if (_myLight)
		{
			_myLight.enabled = false;
		}
		else
		{
			Debug.Log("Unable to turn off lights. Light is null.", this);
		}
	}

	void Update ()
	{
		if (rotationEnabled)
		{
			transform.Rotate(0, yAngle * rotationsPerMinute * rotationSpeedModifier * Time.deltaTime, 0);
		}
	}
}





