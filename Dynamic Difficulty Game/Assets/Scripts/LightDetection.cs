using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour {

	GameObject player;
	bool activated;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update(){
		//Creates a raycast in the direction of the player from the lightsource. This fixes the issue of being detected in light, through walls
		Vector3 rayDir = player.transform.position - transform.position;
		float diff = (player.transform.position - transform.position).magnitude;
		float rayLenght = GetComponent<Light>().range;
		RaycastHit hit;
		if (Physics.Raycast(transform.position, rayDir, out hit))
		{
			if (hit.transform.tag == "Player" && diff < rayLenght)
			{
				player.GetComponent<PlayerManager>().isVisible = true;
				activated = true;
				Debug.Log("YOU IN DA LIGHT, GET OUT!");
			}else if (player.GetComponent<PlayerManager>().isVisible && activated)
			{
				Debug.Log("No more light!");
				player.GetComponent<PlayerManager>().isVisible = false;
				activated = false;
			}
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
