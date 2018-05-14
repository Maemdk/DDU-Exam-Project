using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	void Start(){
		DontDestroyOnLoad(gameObject);
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.R))
		{
			LoadNewLevel();
		}
	}

	public void LoadNewLevel(){
		GetComponent<StatisticsManager>().CalculateLevelNumber();

		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}
}