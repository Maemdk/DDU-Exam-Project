using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {

	NavMeshAgent agent;
	public bool patrol;
	public bool chasePlayer;
	public GameObject patrolWaypointHandler;
	int currentWaypoint;
	GameObject player;
	public int distanceToKeep = 3;

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
		if (Physics.Raycast(transform.position, transform.forward, out hit, 5f))
		{
			if (hit.transform.tag == "Player")
			{
				Debug.Log("pew");
			}
		}
	}

}
