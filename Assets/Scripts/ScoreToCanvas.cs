using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreToCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Text> ().text = "X " + GameObject.FindWithTag ("Player").GetComponent<PlayerStats> ().GetScore ().ToString();
	}
}
