using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour 
{
	public float tiltSpeed = 40;

	Rigidbody rb;


	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		if (Input.anyKey) 
		{
			if (Input.GetKey (KeyCode.A)) {
				rb.AddForce (-transform.right * tiltSpeed);
			}

			if (Input.GetKey (KeyCode.D)) {
				rb.AddForce (transform.right * tiltSpeed);
			}

			if (Input.GetKey (KeyCode.W)) {
				rb.AddForce (transform.forward * tiltSpeed);
			}

			if (Input.GetKey (KeyCode.S)) {
				rb.AddForce (-transform.forward * tiltSpeed);
			}
		}
			

	}
}
