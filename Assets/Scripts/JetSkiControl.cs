using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JetSkiControl : MonoBehaviour {

	private Rigidbody rb;

	//public WheelCollider rudderright;
	//public WheelCollider rudderleft;
	//public float maxSteeringAngle;
	public float thrust;
	//public float resistance;
	public float angle;

	//private bool moveforward = false;
	//private bool movereverse = false;
	private float rotateangle = 0.0f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");

		if (moveVertical > 0.0f) {
			rb.AddRelativeForce (Vector3.forward * thrust);
			//moveforward = true;
		}
		if (moveVertical < 0.0f) {
			rb.AddRelativeForce (-Vector3.forward * thrust/2.0f);
			//movereverse = true;
		}
		//if (moveHorizontal != 0.0f)
		//	rb.AddForce (-transform.forward * resistance);

		rotateangle += moveHorizontal * angle;
		rb.rotation = Quaternion.AngleAxis (rotateangle, Vector3.up);

		/* Adding wheel based turning, with a wheel collider (single wheel on the rear of the JetSki
		*
		* **Does not work, requires friction from a plane to operate, and additional wheels** 
		if (moveHorizontal != 0.0f) {
			rudderright.steerAngle = -moveHorizontal;
			rudderleft.steerAngle = -moveHorizontal;
		}
		*/
		//Vector3 turning = new Vector3(0.0f, angle, 0.0f);
		//rb.AddRelativeTorque (moveHorizontal * turning);
	}

}
