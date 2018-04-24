using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public int health = 100;
	public bool isVisible = false;

	void Update(){
		if (health <= 0)
		{
			Death();
		}
	}

	void Death(){
		//THIS IS WHERE THE GAME MANAGER, GAME OVER FUNCTION GET'S CALLED ONCE IT'S MADE YOOOO
		Destroy(gameObject);
		Debug.Log("Game Over!");
	}

}
