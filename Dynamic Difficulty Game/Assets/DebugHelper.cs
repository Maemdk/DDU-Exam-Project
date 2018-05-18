using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugHelper : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
		{
			GameObject.Find("Game Manager").GetComponent<GameManager>().LoadNewLevel();
		}
	}
}
