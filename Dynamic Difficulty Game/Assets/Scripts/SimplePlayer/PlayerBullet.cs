using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	public int damage = 30;

	void Start(){
		Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>());
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "AI")
		{
			other.gameObject.GetComponent<AIManager>().health -= damage;
			Destroy(gameObject);
		} else
		{
			Destroy(gameObject);
		}
	}

}
