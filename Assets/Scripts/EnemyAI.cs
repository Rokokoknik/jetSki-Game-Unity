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

public class EnemyAI : MonoBehaviour {

	public Transform Player; // player 
	public float distance; // store the distance between Enemy and player
	public float rotationSpeed; // enemy body rotaion speed.
	public float moavementSpeed; // enemy monvement speed.
	

	// Update is called once per frame
	void Update () 
	{

			//find the distance between enemy and player
			distance = Vector3.Distance (Player.position, transform.position);

			 //if the player is neer the enemy, the enemy will look and spot the player.
			if(distance <17f)
			{
				look();
			}
			//if the player got colser the enemy starts following him.
			if (distance < 15f) 
			{    //space limit between the enemy's body and the player's body.
				 if(distance >2f)
				{
					//call the follow function
					follow();
				}
				//if the player is too close to the enemy attack the player and hit him


			}


		}  




    //spot the player and rotate the enemy's body towards him
	void look()
	{	
		//find where the player 
		Quaternion rotate = Quaternion.LookRotation(Player.position - transform.position);
		//rotate enemy's body
		transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * rotationSpeed);
	}
	 
	//follow the player whereever he goes.
	void follow()
	{
		//move toword the player.
		transform.Translate (Vector3.forward*moavementSpeed *Time.deltaTime );
	}

	//attack the player by hitting him
	/*void attack()
	{   //declear a RayscastHit object
		RaycastHit hitPlayer;

		//if the player is too close.
		if(Physics.Raycast(transform.position, transform.forward, out hitPlayer))
		{
			//if this is player and not another object
			if(hitPlayer.collider.gameObject.tag=="Player")
			{ 
				//if the player is still healthy
				if(hitPlayer.collider.gameObject.GetComponent<PlayerCharacter>().health > 0f)
				{
                 //Decrease the player's health
				 hitPlayer.collider.gameObject.GetComponent<PlayerCharacter>().health -=0.5f;
				}

			}
		}

	}


     */
}

