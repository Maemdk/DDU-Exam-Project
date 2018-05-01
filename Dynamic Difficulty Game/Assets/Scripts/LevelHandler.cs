using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour {
	public bool levelComplete;
	public bool playIntro = true;

	public enum ObjectiveType{
		assassinate,
		item,
		defend
	}
	public ObjectiveType objectiveType;
	public GameObject assassinationTarget;
	public string objectiveText;
	public GameObject targetLight;
	public float targetLightHeight = 10f;

	GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");

		if (playIntro)
		{
			Introduction();
		}

		if (assassinationTarget.GetComponent<AIManager>() == null)
		{
			Debug.LogError("The assassination target for the level objective is invalid.");
		}
	}

	void Introduction(){
		player.GetComponent<PlayerController>().canControl = false;

		Text uiObjectiveText = GameObject.Find("Objective Text").GetComponent<Text>();
		uiObjectiveText.enabled = true;
		uiObjectiveText.text = "Mission: " + objectiveText;

		Camera.main.GetComponent<Animation>().Play();

		GameObject _targetLight = Instantiate(targetLight, assassinationTarget.transform.position + new Vector3(0,targetLightHeight,0), targetLight.transform.rotation);
		_targetLight.transform.parent = assassinationTarget.transform;

		switch (objectiveType){
			case ObjectiveType.assassinate:
				Debug.Log("You are to kill this mayne");
				break;
		}
	}
}