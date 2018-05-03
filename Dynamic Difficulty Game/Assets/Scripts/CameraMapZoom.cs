using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMapZoom : MonoBehaviour {

	public bool activated;
	public Transform target;
	public float moveSpeed = 5f;

	bool triggered;
	float t;
	
	void Update(){
		if (activated)
		{
			if (GetComponent<CameraFollow>() != null)
			{
				GetComponent<CameraFollow>().enabled = false;
			}
			t += Time.deltaTime/moveSpeed;
			transform.position = Vector3.Lerp(transform.position, target.position, t);
		} else
		{
			if (GetComponent<CameraFollow>() != null)
			{
				GetComponent<CameraFollow>().enabled = true;
			}
			t = 0;
		}

		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			activated = true;
		}

		if (Input.GetKeyUp(KeyCode.LeftControl))
		{
			activated = false;
		}
	}
}
