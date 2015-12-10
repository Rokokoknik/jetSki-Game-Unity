using UnityEngine;
using System.Collections;

public class RampCollide : MonoBehaviour {

	public float thrust;
	//public float angle;

	void OnCollisionEnter (Collision collisionInfo) {
		collisionInfo.rigidbody.AddRelativeForce ((Vector3.forward + Vector3.up) * thrust); 
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
