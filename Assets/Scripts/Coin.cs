using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	public float rotationSpeed = 10f;
	public int scoreValue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerStats>().AddScore(scoreValue);
			gameObject.GetComponent<AudioSource>().Play();
			gameObject.GetComponent<MeshRenderer>().enabled=false;
			Destroy(gameObject,2);

		}

	}
}
