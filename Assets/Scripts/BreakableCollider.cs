using UnityEngine;
using System.Collections;

public class BreakableCollider : MonoBehaviour {

	public float weight;

	void OnCollisionEnter (Collision collisioninfo)
	{
		if (collisioninfo.collider.tag.Equals ("Player")) {

			gameObject.GetComponent<AudioSource>().Play ();
			//gameObject.GetComponent<MeshRenderer>().enabled = false;
			Destroy (gameObject, 0.25f);
			//DestroyObject (gameObject);
			collisioninfo.rigidbody.AddForce (-Vector3.forward * weight);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
