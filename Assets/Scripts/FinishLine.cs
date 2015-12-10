using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

	public string scene;

	void OnCollisionEnter (Collision collisioninfo)
	{
		if (collisioninfo.gameObject.tag == "Player")
			Application.LoadLevel (scene);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
