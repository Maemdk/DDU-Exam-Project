using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepController : MonoBehaviour {

	public float strideLenght = 0.3f;
	public AudioClip footstepSound;
	[Range(0,1)]
	public float stepVolume = 0.5f;
	public float stepAiVolume = 70f;
	
	Vector3 currentPosition;
	Vector3 lastStepPos;

	AudioSource audioSource;

	void Start(){
		lastStepPos = transform.position;
		audioSource = GetComponent<AudioSource>();
	}

	void FixedUpdate(){
		currentPosition = transform.position;
	}

	void Update(){
		float distance = (currentPosition - lastStepPos).magnitude;
		if (distance > strideLenght)
		{
			MakeFootstep();
		}
	}

	void MakeFootstep(){
		lastStepPos = currentPosition;
		audioSource.PlayOneShot(footstepSound, stepVolume);

		//Make AI agent withing X range check out footstep sound
		GameObject[] aiAgents = GameObject.FindGameObjectsWithTag("AI");
		foreach (GameObject agent in aiAgents)
		{
			float distance = (transform.position - agent.transform.position).magnitude;
			if (distance < stepVolume * stepAiVolume)
			{
				agent.GetComponent<AIController>().chasePlayer = true;
			}
		}
	}

}
