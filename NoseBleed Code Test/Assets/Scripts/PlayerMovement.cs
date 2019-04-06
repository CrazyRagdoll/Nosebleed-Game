using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float moveSpeed = 40.0f;

    float horizonalMove = 0.0f;

    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        //Horizontal movement
        horizonalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        //Jump input
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        //Crouching implementation -- Probably wont be used
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        //Move our player with the controller script
        //Using Time.fixedDeltaTime allows us to have a consistant movespeed across all platforms regardless of how often update is called
        controller.Move(horizonalMove * Time.fixedDeltaTime, crouch, jump);

        //Reset the jump variable
        jump = false;
    }
}