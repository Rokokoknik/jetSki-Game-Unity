using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

	public float timer;
	private float initialtimer;
	private float mtimer;
	private bool paused = false;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Text>().color = Color.green;
		initialtimer = timer;
	}
	
	// Update is called once per frame
	void Update () {
		//A boolean value to detect if the game is paused, stops timer
		if (!paused) {
			//Seconds based timer
			timer -= Time.deltaTime;
			//milliseconds based timer
			mtimer = timer * 100;
			//Makes it take off a millisecond 100 times a second
			mtimer -= (Time.deltaTime * 100);
			int minutes = Mathf.FloorToInt (timer / 60f);
			int seconds = Mathf.FloorToInt (timer - minutes * 60);
			int milliseconds = Mathf.FloorToInt (mtimer % 100);
			//Formats the values for use on screen
			string formattime = string.Format ("{0:00}:{1:00};{2:00}", minutes, seconds, milliseconds);
			//Sets the on screen Text element to the current value;
			gameObject.GetComponent<Text>().text = formattime;

		}
		//if (timer > 299f)
		//	gameObject.GetComponent<Text>().color = Color.green;
		if (Mathf.Ceil (timer) == Mathf.Floor (initialtimer/2))
			gameObject.GetComponent<Text>().color = Color.yellow;
		if (Mathf.Ceil (timer) == Mathf.Floor (initialtimer/5))
			gameObject.GetComponent<Text>().color = Color.red;
		if (Mathf.Ceil (timer) == 0.0f) {
			gameObject.GetComponent<Text> ().text = "00:00;00";
			paused = true;
		}
	}
	void setPaused (bool p)
	{
		paused = p;
	}
}
