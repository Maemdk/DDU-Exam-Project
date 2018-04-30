using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour {

	GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update(){
		//Creates a raycast in the direction of the player from the lightsource. This fixes the issue of being detected in light, through walls
		Vector3 rayDir;
		float rayLenght;
		rayDir = player.transform.position - transform.position;
		rayLenght = GetComponent<Light>().range;
		RaycastHit hit;
		if (Physics.Raycast(transform.position, rayDir, out hit, rayLenght))
		{
			if (hit.transform.tag == "Player")
			{
				player.GetComponent<PlayerManager>().isVisible = true;
				Debug.Log("YOU IN DA LIGHT, GET OUT!");
			}
		}else if (player.GetComponent<PlayerManager>().isVisible)
			{
				player.GetComponent<PlayerManager>().isVisible = false;
			}

		//Debug.DrawRay(transform.position, rayDir * rayLenght, Color.red);
	}

	//Old system.

	// void OnTriggerEnter(Collider other){
	// 	if (other.tag == "Player")
	// 	{
	// 		player.GetComponent<PlayerManager>().isVisible = true;
	// 	}
	// }

	// void OnTriggerExit(Collider other){
	// 	if (other.tag == "Player")
	// 	{
	// 		player.GetComponent<PlayerManager>().isVisible = false;
	// 	}
	// }

}
