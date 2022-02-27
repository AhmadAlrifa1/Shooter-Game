using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public float minX = -60f;
	public float maxX = 60f;

    public float sensitivity;
    float rotY = 0f;
    float rotX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
    }

    void Update()
    {
        rotY += Gamepad.current.rightStick.x.ReadValue() * sensitivity;
        transform.localEulerAngles = new Vector3(0, rotY, 0);
        rotX += Gamepad.current.rightStick.y.ReadValue() * sensitivity;
        transform.Rotate(rotX, 0, 0);
    }

    void LateUpdate () 
    {
        transform.parent = player.transform;
    }
}