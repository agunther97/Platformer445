using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Character movement attributes
    public float speed;
    public float jumpForce = 6f;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;

    //GroundCheck controls
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
      Jump();
    }

    void FixedUpdate(){
      Movement();
      
      if(facingRight == false && (moveInput > 0)){
        Flip();
      } else if(facingRight == true && moveInput < 0){
          Flip();
      }
    }

    //Character movement
    void Movement(){
      moveInput = Input.GetAxisRaw("Horizontal");
      rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    //Character jump
    void Jump(){
      //Determines if player is on ground
      isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

      if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true){
        rb.velocity = Vector2.up * jumpForce;
      }
    }

    //Keeps sprite facing in the direction player is moving towards
    void Flip(){
      facingRight = !facingRight;
      Vector3 Scaler = transform.localScale;
      Scaler.x *= -1;
      transform.localScale = Scaler;
    }

    public Rigidbody2D GetRigidbody(){
      return rb;
    }
}