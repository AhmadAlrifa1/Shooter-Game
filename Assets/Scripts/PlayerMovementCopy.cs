using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCopy : MonoBehaviour
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
    }  

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0.0f, vertical);
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jump;
            }
        }

        rot += Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
