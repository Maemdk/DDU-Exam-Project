using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookat : MonoBehaviour {

	public bool active = true;
	public Transform target;

	void LateUpdate () {
		if (active)
		{
			transform.LookAt(target);
		}
	}

	public void Activate(){
		active = true;
	}

	public void Deactivate(){
		active = false;
	}
}
