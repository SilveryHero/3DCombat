using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    public CharacterController controller;
    public Transform cam;
    public float speed = 3.5f;

    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public bool walking;
    public bool isGrounded;
     public Vector3 moveDirect;
    
    private float gravity = -9.8f;
    public float jumpHeight = 20.0f;
    public Vector3 velocity;

    void Start()
    {
        currentHealth = maxHealth;
    }
       void Update() {

  
          if(controller.isGrounded){
            Jump();
        //walk
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction =  new Vector3(horizontalInput, 0, verticalInput).normalized;
       

        if (direction.magnitude >= 0.1f) {
        
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg +cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        moveDirect = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        
        controller.Move(moveDirect.normalized * speed * Time.deltaTime);

        walking = true;
        } else {
            walking = false;
        }
          }
       }



        public void TakeDamage(int damage){
        currentHealth -= damage;
        animator.SetTrigger("Hit");
        if (currentHealth <=0){
            Die();
        }
    }

    void Die() {
        Debug.Log("Player died!");
        animator.SetBool("Dead", true);
        this.enabled = false;
    }
    
    void Jump(){
       //jump
       if (!isGrounded && velocity.y < jumpHeight*5){
            velocity.y = 0f;
        }
        if (Input.GetButtonDown("Jump") && controller.isGrounded){
            velocity.y += (Mathf.Sqrt(jumpHeight * -3.0f * gravity));
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

    }

    }

