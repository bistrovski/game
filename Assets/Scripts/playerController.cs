using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Animator anim;
    public CharacterController controller;
    public float speed = 2;  
    public float turnSpeed = 1000;
    public float gravity = -12;
	public float jumpHeight = 1;
    float velocityY;
    float velocityX;
    void Start()
    {
        
      
    }

    void Update()
    {
        velocityY += Time.deltaTime * gravity; // gravity   
        
        velocityX = Input.GetAxis("Horizontal")  * turnSpeed * Time.deltaTime; // turn right or left
        
        Vector3 velocity  = transform.right * velocityX + transform.forward * speed + Vector3.up * velocityY; // turn right or left + run forward + gravity
        
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        
        controller.Move (velocity * Time.deltaTime); 
        
        

        if (controller.isGrounded) {
			velocityY = 0;
		}

        if(Input.GetButtonDown("Jump")) // jump 
        {            
            Jump();
            
        }

        if(Input.GetAxis("Vertical") < 0) // down
        {
            Down();
            controller.height = 0.9f;
            controller.center = new Vector3 (0 , 0.45f , 0);
        }
        else
        {
            controller.height = 1.8f;
            controller.center = new Vector3 (0 , 0.9f , 0);
        }
    }

    void Jump() {
        
		if (controller.isGrounded) {
            anim.SetTrigger("jump");
			float jumpVelocity = Mathf.Sqrt (-2 * gravity * jumpHeight);
			velocityY = jumpVelocity;
		}
    }

    void Down()
    {
        if(controller.isGrounded)
        {
            anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        }
    }
}
