using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun
{
    private float speed = 6f;
    private float gravity = 20f;
    private float jump = 8f;
    private CharacterController controller;

    private float rotSpeed = 80f;
    private float rot = 0f;
    private float horizontal;
    private float vertical;

    private Vector3 moveDirection = Vector3.zero;


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        if (!photonView.IsMine)
        {
            Destroy(GetComponent<PlayerMovement>());
            Destroy(GetComponent<Animations>());
        }
    }  

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float vertical = Gamepad.current.leftStick.y.ReadValue();
        float horizontal = Gamepad.current.leftStick.x.ReadValue();

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(horizontal, 0.0f, vertical);
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);

            if (Gamepad.current.crossButton.isPressed)
            {
                moveDirection.y = jump;
            }
        }

        rot += Gamepad.current.rightStick.x.ReadValue() * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
