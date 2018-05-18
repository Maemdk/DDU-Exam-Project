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
	GameObject enemyHolder;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}

	public void EngageDDA(){
		CalculateChangeValues();
		StartCoroutine(MakeChanges());
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

	IEnumerator MakeChanges(){
		// This is to make sure objects are loaded from the new scene so we wait for the scene to load. PROLLY NEED TO FIND BETTER SOLUTION... WHAT IF IT LOADS SLOW?=!!!?!? SceneManager.OnLevelLoaded or something
		yield return new WaitForSeconds(1f);
		player = GameObject.FindGameObjectWithTag("Player");
		enemyHolder = GameObject.Find("Variable Enemies");

		// STEALTH THINGS HERE
		// -------------------------------------------------------------
		// RAMBO THINGS HERE
		for (int i = enemyHolder.transform.childCount - 1; i >= 0; i--)
		{
			if (i == ramboNumber)
			{
				break;
			}
			enemyHolder.transform.GetChild(i).gameObject.SetActive(false);
		}

	}

}