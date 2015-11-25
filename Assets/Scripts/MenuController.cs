using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	public GameObject optionsPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel1(){
		Application.LoadLevel ("Level 1");
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
}
