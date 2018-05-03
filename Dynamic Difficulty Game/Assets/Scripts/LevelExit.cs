using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour {

	GameManager gameManager;

	void Start(){
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player")
		{
			gameManager.LoadNewLevel();
		}
	}

}
