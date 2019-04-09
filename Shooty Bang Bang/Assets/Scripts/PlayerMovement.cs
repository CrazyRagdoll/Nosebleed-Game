using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public Joystick joystick;

    public float moveSpeed = 40.0f;

    private float horizonalMove = 0.0f;

    private bool jump = false;
    private bool crouch = false;

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE
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
#endif
#if UNITY_ANDROID || UNITY_IOS
        //Moving horizontally with joystick
        if (joystick.Horizontal >= 0.25f)
        {
            horizonalMove = moveSpeed;
        }
        else if (joystick.Horizontal <= -0.25f)
        {
            horizonalMove = -moveSpeed;
        } else
        {
            horizonalMove = 0.0f;
        }

        //Moving vertically with joystick
        if (joystick.Vertical >= 0.5f)
        {
            jump = true;
        }
        else if (joystick.Vertical <= -0.5f)
        {
            crouch = true;
        }
        else crouch = false;
#endif

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