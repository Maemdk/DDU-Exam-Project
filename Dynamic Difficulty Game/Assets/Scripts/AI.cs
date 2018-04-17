using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {

	NavMeshAgent agent;
	public bool patrol;
	public bool chasePlayer;
	public float chaseTime = 3f;
	float lastSeen;
	public GameObject patrolWaypointHandler;
	int currentWaypoint;
	GameObject player;
	public GameObject bullet;
	public int distanceToKeep = 3;
	public float shootRange = 20f;
	public float fireRate = 0.1f;
	private float lastFire;
	public float bulletSpeed = 10f;

	void Start(){
		agent = GetComponent<NavMeshAgent>();
		agent.autoBraking = false;
		player = GameObject.FindGameObjectWithTag("Player");
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
				chasePlayer = true;
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

		agent.destination = player.transform.position;
		transform.LookAt(player.transform);
		
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, out hit, shootRange))
		{
			if (hit.transform.tag == "Player")
			{
				if (Time.time > lastFire)
				{
					lastFire = Time.time + fireRate;
					
					GameObject _bullet = Instantiate(bullet, transform.GetChild(0).transform.position, transform.rotation);
					_bullet.GetComponent<Rigidbody>().AddForce(_bullet.transform.forward * bulletSpeed * 10);
					Physics.IgnoreCollision(_bullet.GetComponent<Collider>(), GetComponent<Collider>());
					Physics.IgnoreCollision(_bullet.GetComponent<Collider>(), transform.GetChild(0).GetComponent<Collider>());

					lastSeen = Time.time + chaseTime;
				}
			} else if (Time.time > lastSeen)
			{
				patrol = true;
				chasePlayer = false;
			}
		}
	}
}
