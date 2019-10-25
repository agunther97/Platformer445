using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Character movement attributes
    public float speed;
    public float jumpForce = 6f;
    private float moveInput;
    private Rigidbody2D rigidBody;
    private bool facingRight = true;
    public GameObject player;

    //GroundCheck controls
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //Stores Object //Calls GameManager script
   GameObject gO; GameManager gM;

    public Transform getSpawnPos;
    void Start()
    {
        InitPlayerChecks();
    }

    void Update()
    {
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

    public void InitPlayerChecks()
    {
      rigidBody = GetComponent<Rigidbody2D>();

      //Stores GameManager object to gO
        gO= GameObject.Find("GameManager");
        //Calls GameManager script from GameManager object
        gM = gO.GetComponent<GameManager>();

        getSpawnPos.position = gM.spawnPos.position;
    }

    //Character movement
    void Movement(){
      moveInput = Input.GetAxisRaw("Horizontal");
      rigidBody.velocity = new Vector2(moveInput * speed, rigidBody.velocity.y);
    }

    //Character jump
    void Jump(){
      //Determines if player is on ground
      isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

      if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true){
        rigidBody.velocity = Vector2.up * jumpForce;
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
      return rigidBody;
    }

    void OnCollisionEnter2D(Collision2D theCollision){
      Debug.Log("Hit" + theCollision.gameObject.name);

      if(theCollision.gameObject.tag == "Platform"){
        player.transform.parent = theCollision.gameObject.transform;
      }

      if(theCollision.gameObject.tag == "Enemy"){
        player.transform.position = getSpawnPos.position;
        gM.livesLeft--;

      }
    }

    void OnCollisionExit2D(Collision2D theCollision){
      if(theCollision.gameObject.tag == "Platform"){
        player.transform.parent = null;
      }
    }
}