using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{

    private Rigidbody2D rb2D;  //rigidbody component

    public float moveSpeed = 3f; //variable for speed of moving 
    public float jumpForce = 60f; // variable for magnitude of jump 
    public bool isJumping = true; // variable to check if player is jumping
    private float moveHorizontal; // variable to check when moving horizontally 
    private float moveVertical;   // variable to check when moving Vertically 

    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
             

    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = joystick.Horizontal; //getting input from user for moving horizontally and storing it in moveHorizontal
    
        if(joystick.Vertical > 0.5f)
        {
            moveVertical = jumpForce;
        }else
        {
            moveVertical = 0f;
        }
    } 

    private void FixedUpdate()
    {
        if (moveHorizontal > 0.2f || moveHorizontal < -0.2f )   //move if move Horizontal is more than 0.1 or moveHorizontal is less than -0.1
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed , 0f), ForceMode2D.Impulse); 
        }

        if (!isJumping)  //jump if isjumping is false and move vertical is more than 0.1
        {
            rb2D.AddForce(new Vector2(0f, moveVertical ), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "Platform") //set isjumping to false me player is colliding with platform 
        {
            isJumping = false; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //set isjumping to true if player stops collision with platform 
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = true; 
        }
    }
     
}
