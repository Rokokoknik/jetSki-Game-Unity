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
	private AudioSource jetskiidle;
	private AudioSource jetskimove;
	private AudioSource jetskisplash;
	private bool moveclip;
	private bool idleclip;
	private bool inair;
	private Vector3 getposition;
	//public AudioClip[] clips;

	//private bool moveforward = false;
	//private bool movereverse = false;
	private float rotateangle = 0.0f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		AudioSource[] clips = GetComponents<AudioSource>();
		jetskiidle = clips [0];
		jetskimove = clips [1];
		jetskisplash = clips [2];

	}

	void OnCollisionEnter (Collision collisioninfo) {
		if (collisioninfo.gameObject.tag == "Ramp") {
			jetskiidle.Stop ();
			idleclip = true;
			jetskimove.Stop ();
			moveclip = true;
		}
	}

	void OnCollisionExit (Collision collisioninfo) {
		if (collisioninfo.gameObject.tag == "Ramp") {
			inair = true;
		}
	}


	void FixedUpdate()
	{
		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");
		getposition = transform.position;

		if (inair && getposition.y <= 232) {
			jetskisplash.Play ();
			idleclip = false;
			moveclip = false;
			inair = false;
		}
		if (moveVertical > 0.0f) {
			rb.AddRelativeForce (Vector3.forward * thrust);
			if (!moveclip) {
				jetskimove.Play ();
				jetskiidle.Stop ();
				idleclip = false;
				moveclip = true;
			}
			//clips [1] = gameObject.AddComponent ("AudioSource") as AudioSource;
			//moveforward = true;
		} else if (moveVertical < 0.0f) {
			rb.AddRelativeForce (-Vector3.forward * thrust / 2.0f);
			if (!moveclip) {
				jetskimove.Play ();
				jetskiidle.Stop ();
				idleclip = false;
				moveclip = true;
			}
			//clips [1] = gameObject.AddComponent ("AudioSource") as AudioSource;
			//movereverse = true;
		} else {
			if (!idleclip) {
				jetskiidle.Play ();
				jetskimove.Stop ();
				moveclip = false;
				idleclip = true;
			}
		}
		//clips [0] = gameObject.AddComponent ("AudioSource") as AudioSource;
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
