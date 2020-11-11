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
        
        velocityX = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed; // turn right or left
        
        Vector3 velocity  = Vector3.right * velocityX + transform.forward * speed + Vector3.up * velocityY; // turn right or left + run forward + gravity
        
        
        controller.Move (velocity * Time.deltaTime); 

        if (controller.isGrounded) {
			velocityY = 0;
		}

        if(Input.GetButtonDown("Jump")) // jump 
        {            
            Jump();
            
        }
    }

    void Jump() {
        
		if (controller.isGrounded) {
            anim.SetTrigger("jump");
			float jumpVelocity = Mathf.Sqrt (-2 * gravity * jumpHeight);
			velocityY = jumpVelocity;
		}
    }
}
