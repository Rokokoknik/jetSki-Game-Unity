using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
	public GameObject optionsPanel;
	public GameObject soundSlider;
	public GameObject fieldOfViewSlider;
	public static float fieldOfView=60;

	// Use this for initialization
	void Start () {
		soundSlider.GetComponent<Slider> ().value = AudioListener.volume;
		fieldOfViewSlider.GetComponent<Slider> ().value = fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
	//	Debug.Log(AudioListener.volume);
	//	Debug.Log(GameObject.FindGameObjectsWithTag ("MainCamera") [0].gameObject.GetComponent<Camera> ().fieldOfView);
	}

	public void LoadLevel1(){

	}

	public void ToggleOptionsPanel(){
		if(optionsPanel.activeSelf==true){
			optionsPanel.SetActive (false);
		}
		else if(optionsPanel.activeSelf==false){
			optionsPanel.SetActive (true);
		}
	
	}

	public void ExitGame(){
		Application.Quit ();
	}

	public void ChangeSoundVolume(){
		AudioListener.volume = soundSlider.GetComponent<Slider>().value;
	}

	public void ChangeFieldOfView(){
		fieldOfView = fieldOfViewSlider.GetComponent<Slider> ().value;
		GameObject.FindGameObjectsWithTag ("MainCamera") [0].gameObject.GetComponent<Camera> ().fieldOfView = fieldOfViewSlider.GetComponent<Slider> ().value;
	}

	public void RestartLevel(){
		Application.LoadLevel (Application.loadedLevelName);
	}
}
