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
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		GetComponent<DynamicDiffManager>().EngageDDA();
	}
}