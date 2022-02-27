using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneDropManager : MonoBehaviour
{
	public Transform end;
	public float speed;

	public Camera cr;

	public Transform player;
	bool spawned = false;
 
     void FixedUpdate ()
     {
         Vector3 a = transform.position;
		 Vector3 b = end.position;
		 transform.position = Vector3.MoveTowards(a, b, speed);
     }

	 void Update()
	 {
		 if(Gamepad.current.crossButton.isPressed && spawned == false)
		 {
			 Instantiate(player, transform.position, transform.rotation);
			 Destroy(cr);
			 spawned = true;
		 }

		 if(Keyboard.current.spaceKey.isPressed && spawned == false)
		 {
			 Instantiate(player, transform.position, transform.rotation);
			 Destroy(cr);
			 spawned = true;
		 }
	 }
}