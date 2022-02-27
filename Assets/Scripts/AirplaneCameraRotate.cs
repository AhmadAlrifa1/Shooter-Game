using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AirplaneCameraRotate : MonoBehaviour
{
    public Transform Airplane;
    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
    public float RotationSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - Airplane.position;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion camTurnAngle = Quaternion.AngleAxis(Gamepad.current.rightStick.x.ReadValue() * RotationSpeed, Vector3.up);

        _cameraOffset = camTurnAngle * _cameraOffset;

        Vector3 newPos = Airplane.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        transform.LookAt(Airplane);
    }
}
