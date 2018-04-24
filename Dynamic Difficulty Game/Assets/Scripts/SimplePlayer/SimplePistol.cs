using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePistol : MonoBehaviour {

	public GameObject bullet;
	public AudioClip fireSound;
	[Range(0,1)]
	public float fireVolume = 1f;
	public float aiHearRange = 10f;
	public float bulletSpeed = 5f;

	AudioSource audioSource;

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			Shoot();
		}
	}

	void Shoot(){
		GameObject _bullet = Instantiate(bullet, transform.position, transform.rotation);
		Rigidbody rb = _bullet.GetComponent<Rigidbody>();
		rb.AddForce(_bullet.transform.forward * bulletSpeed * 10);
		Physics.IgnoreCollision(_bullet.GetComponent<Collider>(), GetComponent<Collider>());
		audioSource.PlayOneShot(fireSound, fireVolume);

		//Make all AIs chase player
		GameObject[] aiAgents = GameObject.FindGameObjectsWithTag("AI");
		foreach (GameObject agent in aiAgents)
		{
			float distance = (transform.position - agent.transform.position).magnitude;
			if (distance < aiHearRange)
			{
				agent.GetComponent<AIController>().chasePlayer = true;
			}
		}
	}
}
