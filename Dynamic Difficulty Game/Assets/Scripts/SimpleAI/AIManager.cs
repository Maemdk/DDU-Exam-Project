using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {

	public int health = 100;

	void Update(){
		if (health <= 0)
		{
			Death();
		}
	}

	void Death(){
		GameObject.Find("Game Manager").GetComponent<StatisticsManager>().killCount++;
		Destroy(gameObject);
	}

}
