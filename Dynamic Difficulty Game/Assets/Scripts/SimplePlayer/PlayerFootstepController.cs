using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepController : MonoBehaviour {

	public float strideLenght = 0.3f;
	public AudioClip footstepSound;
	public AudioClip sneakSound;
	[Range(0,1)]
	public float stepVolume = 0.5f;

	//Determines the range of which AI hear the footsteps, the value is not in unity units and are arbitrary
	public float stepAiVolume = 70f;
	[Range(0,1)]
	public float sneakChange = 0.5f;
	
	Vector3 currentPosition;
	Vector3 lastStepPos;

	AudioSource audioSource;

	GameObject player;

	void Start(){
		lastStepPos = transform.position;
		audioSource = GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void FixedUpdate(){
		currentPosition = transform.position;
	}

	void Update(){
		float distance = (currentPosition - lastStepPos).magnitude;
		if (distance > strideLenght)
		{
			if (player.GetComponent<PlayerController>().isSneaking)
			{
				MakeFootstep(sneakSound);
			} else
			{
				MakeFootstep(footstepSound);
			}
			
		}
	}

	void MakeFootstep(AudioClip audioClip){
		lastStepPos = currentPosition;
		audioSource.PlayOneShot(audioClip, stepVolume);

		//Make AI agent withing X range check out footstep sound
		GameObject[] aiAgents = GameObject.FindGameObjectsWithTag("AI");
		foreach (GameObject agent in aiAgents)
		{
			float distance = (transform.position - agent.transform.position).magnitude;

			if (player.GetComponent<PlayerController>().isSneaking)
			{
				if (distance < (stepVolume * stepAiVolume) * sneakChange)
				{
					agent.GetComponent<AIController>().chasePlayer = true;
				}
			} else
			{
				if (distance < stepVolume * stepAiVolume)
				{
					agent.GetComponent<AIController>().chasePlayer = true;
				}
			}
		}
	}

}
