using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Animations : MonoBehaviourPun
{
    private Animator anim;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (base.photonView.IsMine)
        {
            UpdateMovingBoolean();
        }
    }

    private void UpdateMovingBoolean()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isRunningBackward", true);
        }
        else
        {
            anim.SetBool("isRunningBackward", false);
        }

        if (Input.GetMouseButton(1))
        {
            anim.SetBool("isAiming", true);
        }
        else
        {
            anim.SetBool("isAiming", false);
        }
    }
}
