using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePistol : MonoBehaviour {

	public GameObject bullet;
	public float bulletSpeed = 5f;

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
	}

}
