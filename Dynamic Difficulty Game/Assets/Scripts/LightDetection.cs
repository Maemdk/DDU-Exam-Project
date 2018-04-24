using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour {

	GameObject player;

	void Start(){
		//Set the detection range, to the range of the lightsource
		GetComponent<SphereCollider>().radius = GetComponent<Light>().range;

		player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player")
		{
			player.GetComponent<PlayerManager>().isVisible = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player")
		{
			player.GetComponent<PlayerManager>().isVisible = false;
		}
	}

}
