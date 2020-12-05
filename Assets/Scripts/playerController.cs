using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerController : MonoBehaviour
{
    public Animator anim;
    public CharacterController controller;
    public TextMeshProUGUI pointsTime;
    private GameObject gem;
    public float speed = 2;  
    public float turnSpeed = 2;
    public float gravity = -12;
	public float jumpHeight = 1;
    float velocityY , velocityX;
    private int points;  
    void Start()
    {

    }

    void Update()
    {

        velocityX = Input.GetAxis("Horizontal") *turnSpeed; // turn right or left
        velocityY += Time.deltaTime * gravity; // gravity  
        Vector3 velocity  = transform.forward * speed + Vector3.up * velocityY + transform.right * velocityX; // turn right or left + run forward + gravity

        controller.Move (velocity * Time.deltaTime); // to move controller
        
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));// animation
            
        if(controller.isGrounded){
            velocityY = 0;
        }

        if(Input.GetButtonDown("Jump")){
            Jump();
        }
        points++;
        pointsTime.text = (points * 0.01).ToString("F0");// points

        
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {    
        if(hit.collider.gameObject.tag == "Obstacle"){       
            points = 0;
            this.gameObject.transform.position = new Vector3(10, 1, 2);
        }else if(hit.collider.gameObject.tag == "BonusPoints")
        {
            Destroy(hit.collider.gameObject);
            points = points + 500;
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
