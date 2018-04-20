using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Waypoint : MonoBehaviour {

	public bool visibleOnGameStart = false;

	void Start () {
		if (!visibleOnGameStart)
		{
			gameObject.GetComponent<MeshRenderer>().enabled = false;
		}
	}

}
