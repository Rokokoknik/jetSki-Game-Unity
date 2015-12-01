using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

	public float timer;
	private float mtimer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		mtimer = timer * 100;
		mtimer -= (Time.deltaTime * 100);
		int minutes = Mathf.FloorToInt (timer / 60f);
		int seconds = Mathf.FloorToInt (timer - minutes * 60);
		int milliseconds = Mathf.FloorToInt (mtimer % 100);
		string formattime = string.Format ("{0:00}:{1:00};{2:00}", minutes, seconds, milliseconds);

		gameObject.GetComponent<Text>().text = formattime;
		if (timer > 299f)
			gameObject.GetComponent<Text>().color = Color.green;
		if (timer == 60f)
			gameObject.GetComponent<Text>().color = Color.yellow;
		if (timer == 20f)
			gameObject.GetComponent<Text>().color = Color.red;

	}
}
