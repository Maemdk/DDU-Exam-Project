using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	public int damage = 30;
	bool hasKilled;

	void Start(){
		Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>());
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "AI")
		{
			other.gameObject.GetComponent<AIManager>().health -= damage;
			if (other.gameObject.GetComponent<AIManager>().health - damage <= 0 && !hasKilled)
			{
				hasKilled = true;
				GameObject.Find("Game Manager").GetComponent<DynamicDiffManager>().ramboKillCount++;
			}
			Destroy(gameObject);
		} else
		{
			Destroy(gameObject);
		}
	}

}
