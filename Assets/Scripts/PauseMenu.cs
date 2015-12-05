using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseMenu;
	public GameObject optionsPanel;
	public GameObject orbitTarget;
	public GameObject cameraRotation;
	private Vector3 cameraOriginalLocation;
	private Quaternion cameraOriginalRotation;
	public float rotationSpeed;
	// Use this for initialization
	void Start () {
		cameraOriginalLocation = cameraRotation.transform.position;
		cameraOriginalRotation = cameraRotation.transform.rotation;
		rotationSpeed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(pauseMenu.activeSelf==true){
				pauseMenu.SetActive (false);
				Time.timeScale = 1;
				rotationSpeed=0;
				cameraRotation.transform.position =cameraOriginalLocation;
				cameraRotation.transform.rotation=cameraOriginalRotation;
				if(optionsPanel.activeSelf==true){
					optionsPanel.SetActive (false);
				}
			}
			else if(pauseMenu.activeSelf==false){
				pauseMenu.SetActive (true);
				rotationSpeed=0.5f;
				Time.timeScale = 0;


				 
			}
		}
		cameraRotation.transform.RotateAround (orbitTarget.transform.position, Vector3.up,   rotationSpeed);
	}
}
