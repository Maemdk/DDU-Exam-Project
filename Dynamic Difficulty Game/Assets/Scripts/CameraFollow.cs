using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public Vector3 offset = new Vector3(0, 30, 0);

	void Update () {
		transform.position = target.transform.position + offset;
	}
}
