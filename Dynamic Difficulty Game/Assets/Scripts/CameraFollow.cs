﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;

	Vector3 offset;

	void Start(){
		offset = transform.position - target.transform.position;
	}

	void Update () {
		transform.position = target.transform.position + offset;
	}
}
