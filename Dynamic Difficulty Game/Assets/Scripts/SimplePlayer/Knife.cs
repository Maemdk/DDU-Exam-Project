using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {

	public AudioClip sound;
	public int damage = 1000;
	bool applyDamage = true;

	AudioSource audioSource;
	GameObject target;

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
		if (target != null)
		{
			target.GetComponent<AIManager>().health -= damage;
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
