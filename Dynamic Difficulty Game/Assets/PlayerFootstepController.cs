using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepController : MonoBehaviour {

	public float strideLenght = 0.3f;
	public AudioClip footstepSound;
	
	Vector3 currentPosition;
	Vector3 lastStepPos;

	void Start(){
		lastStepPos = transform.position;
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
		GetComponent<AudioSource>().PlayOneShot(footstepSound);
	}

}
