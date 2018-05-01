using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public bool canControl = true;

	public float moveSpeed = 1f;
	[Range(0,1)]
	public float sneakSpeed = 0.5f; // 1 is 100% of movespeed, 0 is 0% of move speed.
	public float rotateSpeed = 1f;

	public bool isSneaking;

	void FixedUpdate(){
		if (canControl)
		{
			Movement();
			MouseLook();
		}
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			isSneaking = true;
		}

		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			isSneaking = false;
		}
	}

	void Movement(){
		float xMove = Input.GetAxisRaw("Horizontal");
		float yMove = Input.GetAxisRaw("Vertical");

		Vector3 movement = new Vector3(xMove,0,yMove).normalized / 8;
		if (isSneaking)
		{
			transform.Translate((movement * (moveSpeed * sneakSpeed)) / 2, Space.World);
		}else
		{
			transform.Translate((movement * moveSpeed) / 2, Space.World);
		}
	}

	//MouseLook was taken from http://wiki.unity3d.com/index.php?title=LookAtMouse

	//To save time of course. Will make my own once we move to a more advanced player controller
	void MouseLook(){
		// Generate a plane that intersects the transform's position with an upwards normal.
    	Plane playerPlane = new Plane(Vector3.up, transform.position);
 
    	// Generate a ray from the cursor position
    	Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
 
    	// Determine the point where the cursor ray intersects the plane.
    	// This will be the point that the object must look towards to be looking at the mouse.
    	// Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
    	//   then find the point along that ray that meets that distance.  This will be the point
    	//   to look at.
    	float hitdist = 0.0f;
    	// If the ray is parallel to the plane, Raycast will return false.
    	if (playerPlane.Raycast (ray, out hitdist)) 
		{
        	// Get the point along the ray that hits the calculated distance.
        	Vector3 targetPoint = ray.GetPoint(hitdist);
 
        	// Determine the target rotation.  This is the rotation if the transform looks at the target point.
        	Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
 
        	// Smoothly rotate towards the target point.
        	transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
		}
	}
}
