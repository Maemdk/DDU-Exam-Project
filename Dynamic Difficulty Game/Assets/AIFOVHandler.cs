using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFOVHandler : MonoBehaviour {

	public bool playerInside;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player")
		{
			playerInside = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player")
		{
			playerInside = false;
		}
	}

}
