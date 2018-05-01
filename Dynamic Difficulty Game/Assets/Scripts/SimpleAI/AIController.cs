using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour {

	public bool patrol;
	public bool chasePlayer;
	public float chaseTime = 3f;
	public float closeDetectionRange = 1f;
	public int distanceToKeep = 3;
	public float shootRange = 20f;
	public float fireRate = 0.1f;
	public float bulletSpeed = 10f;
	public float lookAtSpeed = 1f;
	public GameObject bullet;
	public AudioClip shootSound;
	public GameObject patrolWaypointHandler;

	int currentWaypoint;
	float lastFire;
	float lastSeen;
	GameObject player;
	NavMeshAgent agent;
	Vector3 playerLastKnownPos;
	AudioSource audioSource;
	bool wasPatrol;
	
	void Start(){
		agent = GetComponent<NavMeshAgent>();
		agent.autoBraking = false;
		player = GameObject.FindGameObjectWithTag("Player");
		audioSource = GetComponent<AudioSource>();
	}

	void Update(){
		if (patrol && agent.remainingDistance < 0.5f)
		{
			GoToNextWaypoint();
		}

		if (chasePlayer)
		{
			ChaseAndShoot();
		}

		Vector3 raycastDir = player.transform.position - transform.position;

		RaycastHit hit;
		if (Physics.Raycast(transform.position, raycastDir, out hit) && transform.GetChild(1).GetComponent<AIFOVHandler>().playerInside && !chasePlayer)
		{
			if (hit.transform.tag == "Player")
			{
				if (player.GetComponent<PlayerManager>().isVisible)
				{
					chasePlayer = true;
				} else if ((player.transform.position - transform.position).magnitude < closeDetectionRange)
				{
					chasePlayer = true;
				}
			}
		}
	}

	void GoToNextWaypoint(){
		agent.destination = patrolWaypointHandler.transform.GetChild(currentWaypoint).position;

		currentWaypoint = (currentWaypoint + 1) % patrolWaypointHandler.transform.childCount;
	}

	void ChaseAndShoot(){
		if (patrol == true)
				patrol = false;

		float distance = (player.transform.position - transform.position).magnitude;
		Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookAtSpeed * Time.deltaTime);

		agent.destination = player.transform.position;
		
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit, shootRange))
		{
			if (hit.transform.tag == "Player")
			{
				if (distance <= distanceToKeep)
				{
					agent.destination = transform.position;
				}

				if (Time.time > lastFire)
				{
					lastFire = Time.time + fireRate;
					
					GameObject _bullet = Instantiate(bullet, transform.GetChild(0).transform.position, transform.rotation);
					_bullet.GetComponent<Rigidbody>().AddForce(_bullet.transform.forward * bulletSpeed * 10);
					Physics.IgnoreCollision(_bullet.GetComponent<Collider>(), GetComponent<Collider>());
					Physics.IgnoreCollision(_bullet.GetComponent<Collider>(), transform.GetChild(0).GetComponent<Collider>());
					audioSource.PlayOneShot(shootSound);

					GameObject[] aiAgents = GameObject.FindGameObjectsWithTag("AI");
					foreach (GameObject agent in aiAgents)
					{
						float _distance = (transform.position - agent.transform.position).magnitude;
						if (distance < 10)
						{
							agent.GetComponent<AIController>().chasePlayer = true;
						}
					}
				}

				lastSeen = Time.time + chaseTime;
			} 
			else if (Time.time > lastSeen)
			{
				patrol = true;
				chasePlayer = false;
			}
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player")
		{
			chasePlayer = true;
		}
	}
}
