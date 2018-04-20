using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBullet : MonoBehaviour {

	public int damage = 10;

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<PlayerManager>().health -= damage;
			Destroy(gameObject);
		} else
		{
			Destroy(gameObject);
		}
	}

}
