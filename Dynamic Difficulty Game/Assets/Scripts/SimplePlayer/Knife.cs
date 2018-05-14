using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {

	public AudioClip sound;
	public int damage = 1000;

	bool applyDamage = true;
	AudioSource audioSource;
	GameObject target;
	GameObject[] nearbyEnemies;

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.F))
		{
			Attack();
		}
	}

	void Attack(){
		audioSource.PlayOneShot(sound);

		if (true)
		{
			
		}

		if (target != null)
		{
			target.GetComponent<AIManager>().health -= damage;
			if (target.GetComponent<AIManager>().health - damage <= 0)
			{
				GameObject.Find("Game Manager").GetComponent<StatisticsManager>().stealthKillCount++;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "AI")
		{
			target = other.gameObject;
			Debug.Log("Ai in range");
		}
	}

	void OnTriggerExit(Collider other){
		if (other == target)
		{
			target = null;
		}
	}
}
