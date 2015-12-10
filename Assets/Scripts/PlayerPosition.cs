/* 
 * Meshari Alshammari 
 * B00549132
 * CSCI4168 Assignment
 * References: 
 * https://www.youtube.com/watch?v=YMDnKnsWoAs
 * https://www.youtube.com/watch?v=188SMf9f6UY
 */
using UnityEngine;
using System.Collections;

public class PlayerPosition : MonoBehaviour {

	public Transform body;// players body.
	public float yPos;//the player's y xis position 

	void Update () 

	{  
		  //find his y xis position
			yPos = body.position.y;
		

	}  


}
