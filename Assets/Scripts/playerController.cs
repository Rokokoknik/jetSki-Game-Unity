//Code from Unity example, altered for Unity 5, further altered as a starting point for game movement
//Requires a rigidbody for the object to be controlled
using UnityEngine;
using System.Collections;

/*[System.Serializable] //Makes the Variables adjustable in the inspector, in a seperate dropdown
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}*/

public class playerController : MonoBehaviour 
{
	//Rigidbody replaces GetComponent calls (previous versions of Unity required)
	private Rigidbody rb;

	//Allows rb to be used in place of repeated GetComponent calls
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	//Sets a currentspeed, maxspeed, acceleration amount, deceleration amount, tilt (unused currently), angle, and
	//rotate angle variables that are all accessible from within the inspector to adjust movement amounts in testing.
	public float currentspeed;
	public float maxspeed;
	public float acceleration;
	public float deceleration;
	public float tilt;
	public float angle;
	public float rotateangle = 0.0f;

	private bool movingforward = false;
	private bool movingbackward = false;
	/*public Boundary boundary;*/

	void FixedUpdate()
	{
		//Grabs value from the Vertical axis movement (currently the up arrow or w key, and down arrow or s key)
		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");
		//Vector3 movement = new Vector3 (0.0f, moveVertical, 0.0f);

		//Checks to see what kind of movement to take (forward, backwards, or braking)
		if (moveVertical > 0.0f && !movingbackward) {
			rb.velocity = rb.transform.TransformDirection (Vector3.forward * currentspeed);
			//rb.AddForce(transform.forward * (currentspeed/2.0f));
			movingforward = true;
			if (currentspeed < maxspeed)
				currentspeed += acceleration;
		} else if (moveVertical < 0.0f && !movingforward) {
			rb.velocity = rb.transform.TransformDirection (-Vector3.forward * currentspeed);
			//rb.AddForce (-transform.forward * currentspeed);
			movingbackward = true;
			if (currentspeed < maxspeed)
				currentspeed = currentspeed/2.0f + acceleration;
		} else {
			rb.velocity = rb.transform.TransformDirection (Vector3.forward * currentspeed);
			if (currentspeed > 0.0f)
			{
				currentspeed -= deceleration;
				if (currentspeed <= 0.0f)
				{
					currentspeed = 0.0f;
					movingforward = false;
					movingbackward = false;
				}
			}
		}
		rotateangle += moveHorizontal * angle;
		rb.rotation = Quaternion.AngleAxis (rotateangle, Vector3.up);
			//rb.velocity = movement * speed;
		//playerRotate (moveHorizontal);

		//Adds a boundary to prevent the player from travelling outside a given min max range.
		/*rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);*/
		//Used for controling tilt
		//rb.rotation = Quaternion.Euler (rb.velocity.z * -tilt, 0.0f, rb.velocity.x * -tilt);
		//rb.rotation = Quaternion.Euler (rb.velocity.z * tilt, 0.0f, 0.0f);
	}

	//Update used for controlling rotation
	/*void Update()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		rotateangle += moveHorizontal * angle;
		if (moveHorizontal != 0) {
			playerRotate (rotateangle);
		}
	}

	//Still needs to be cleaned up, but currently used for rotation based on rotateangle amount
	//calculated above
	void playerRotate(float rotateangle)
	{
		/*if (moveHorizontal > 0)
			transform.Rotate (0, 30, 0);
		else if (moveHorizontal < 0)
			transform.Rotate (0, 330, 0);
		else
			;

		rb.rotation = Quaternion.AngleAxis (rotateangle, Vector3.up);
	}*/
}
