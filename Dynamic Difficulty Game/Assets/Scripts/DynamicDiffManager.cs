using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicDiffManager : MonoBehaviour {

	[Header("Main DDU Numbers")]
	// The main determining factors in the DDA system
	public int stealthNumber;
	public int ramboNumber;
	public int overallNumber; // The two others combined

	[Header("Stats")]
	public float sneakTime;
	public int ramboKillCount;
	public int stealthKillCount;

	GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}

	public void EngageDDA(){
		CalculateChangeValues();
		MakeChanges();
	}

	// Finds whether to assisn a point to stealth or rambo - Use it after a stage is cleared
	void CalculateChangeValues(){
		if (ramboKillCount > stealthKillCount)
		{
			ramboNumber++;
		} else {
			stealthNumber++;
		}

		if (sneakTime > 25){
			stealthNumber++;
		}

		overallNumber += (stealthNumber + ramboNumber);
	}

	void MakeChanges(){
		// STEALTH THINGS HERE
		player.GetComponent<PlayerController>().moveSpeed = 0.1f;
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().moveSpeed = 0.1f;

		// -------------------------------------------------------------
		// RAMBO THINGS HERE


	}

}