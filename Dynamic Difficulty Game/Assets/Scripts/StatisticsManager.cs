using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : MonoBehaviour {

	[Header("Main DDU Numbers")]
	// The main determining factors in the DDA system
	public int stealthNumber;
	public int ramboNumber;
	public int overallNumber; // The two others combined

	[Header("Stats")]
	public float sneakTime;
	public int ramboKillCount;
	public int stealthKillCount;

	// Finds whether to assisn a point to stealth or rambo - Use it after a stage is cleared
	public void CalculateLevelNumber(){
		
	}

}