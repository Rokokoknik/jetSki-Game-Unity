using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	private int currentScore;

	// Use this for initialization
	void Start () {
		this.currentScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (currentScore);
	}

	public void AddScore(int score){
		this.currentScore += score;
	}
}
