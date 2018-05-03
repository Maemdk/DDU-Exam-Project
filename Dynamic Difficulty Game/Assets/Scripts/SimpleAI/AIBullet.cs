using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBullet : MonoBehaviour {

	public int damage = 10;

	// USE A RAYCAST INSTEAD- FASTER, BETTER PERFORMANCE AND FIXES PUSH PROBLEM (Shoot raycast 0.01m infront of bullet, check for player)

	void FixedUpdate(){
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit, 0.5f))
		{
			if (hit.transform.tag == "Player")
			{
				hit.transform.gameObject.GetComponent<PlayerManager>().health -= damage;
	 			Destroy(gameObject);
			}else{
				Destroy(gameObject);
			}
		}

		Debug.DrawRay(transform.position, transform.forward);
	}

	// void OnCollisionEnter(Collision other){
	// 	if (other.gameObject.tag == "Player")gi
	// 	{
	// 		other.gameObject.GetComponent<PlayerManager>().health -= damage;
	// 		Destroy(gameObject);
	// 	} else
	// 	{
	// 		Destroy(gameObject);
	// 	}
	// }

}
