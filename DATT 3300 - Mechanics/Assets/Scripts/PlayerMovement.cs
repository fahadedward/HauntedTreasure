using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float walkSpeed = 20f;
    public float runningSpeed = 26f;

    public float gravity = -9.81f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    
    Vector3 normalized;


    
    public void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // use this because we want local movements instead of global
         Vector3 move = transform.right * x + transform.forward * z;
         normalized = move.normalized;
    }
    void Running()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            walkSpeed = runningSpeed;
            
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            walkSpeed = 20f;
            
        }
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        Movement();
        Running();
        controller.Move(normalized * walkSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

       

    }
}
