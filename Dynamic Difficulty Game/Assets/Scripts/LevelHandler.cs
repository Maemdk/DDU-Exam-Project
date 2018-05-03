﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour {
	public bool playIntro = true;
	public GameObject endDoor;

	public enum ObjectiveType{
		assassinate,
		item,
		defend
	}
	[Header("Objective")]
	public ObjectiveType objectiveType;
	public GameObject assassinationTarget;
	public string objectiveText;
	public GameObject targetLight;
	public float targetLightHeight = 10f;

	GameObject player;
	GameObject camera;
	bool introCamAnimCheck;
	Transform camOrigTrans;

	bool assassination;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
		camera = Camera.main.gameObject;
		camOrigTrans = camera.transform;

		if (playIntro)
		{
			Introduction();
		}

		if (assassinationTarget.GetComponent<AIManager>() == null)
		{
			Debug.LogError("The assassination target for the level objective is invalid.");
		}

		if (endDoor == null)
		{
			endDoor = GameObject.Find("EndDoor");
		}

		switch (objectiveType){
			case ObjectiveType.assassinate:
				assassination = true;
				break;
		}
	}

	void Update(){
		//Gets called once the intro animation on the main camera is done playing
		if (introCamAnimCheck && !Camera.main.GetComponent<Animation>().isPlaying)
		{
			player.GetComponent<PlayerController>().canControl = true;
			camera.transform.position = camOrigTrans.position;
			camera.transform.rotation = camOrigTrans.rotation;
		}

		if(assassination){
			if (assassinationTarget.GetComponent<AIManager>().health <= 0)
			{
				Debug.Log("Target wanked!");
				ActivateExit();
			}
		}
	}

	void Introduction(){
		player.GetComponent<PlayerController>().canControl = false;

		Text uiObjectiveText = GameObject.Find("Objective Text").GetComponent<Text>();
		uiObjectiveText.enabled = true;
		uiObjectiveText.text = "Mission: " + objectiveText;

		camera.GetComponent<Animation>().Play();
		introCamAnimCheck = true;

		GameObject _targetLight = Instantiate(targetLight, assassinationTarget.transform.position + new Vector3(0,targetLightHeight,0), targetLight.transform.rotation);
		_targetLight.transform.parent = assassinationTarget.transform;
	}

	void ActivateExit(){
		endDoor.transform.Find("Light").GetComponent<Light>().color = Color.green;
		endDoor.transform.Find("Door").gameObject.SetActive(false);
	}
}