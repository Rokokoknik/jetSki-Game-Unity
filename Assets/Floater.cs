using UnityEngine;
using System.Collections;

public class Floater : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < 2.68) {                                                  
			Debug.Log(gameObject.transform.position.y +" AND "+ gameObject.GetComponent<Rigidbody> ().velocity);
		    gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * 8.5f);
		
		


		}
	}
}
