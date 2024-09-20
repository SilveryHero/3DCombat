using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public CharacterController controller;
    private float gravity = -9.8f;
    public float jumpHeight = 20.0f;
    public Vector3 velocity;
    void Update()
    {
               //jump
       if (!controller.isGrounded && velocity.y < jumpHeight*10)
        {
            velocity.y = 0f;
        }
        if (Input.GetButtonDown("Jump") && controller.isGrounded){
            velocity.y += (Mathf.Sqrt(jumpHeight * -3.0f * gravity));
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }
       }