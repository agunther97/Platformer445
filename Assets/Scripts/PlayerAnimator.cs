using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAnimator : MonoBehaviour
{
    private Animator animate;

    private PlayerController player;

    GameObject gO; GameManager gM;


    void Start()
    {
        InitAnimateChecks();
    }

    void Update()
    {
        AnimateControls();   
    }

    public void InitAnimateChecks()
    {
        animate = GetComponent<Animator>();
        player = GetComponent<PlayerController>();

        //Stores GameManager object to gO //Calls GameManager script from GameManager object
        gO= GameObject.Find("GameManager"); gM = gO.GetComponent<GameManager>();
    }

    void AnimateControls(){
        //Animate Running
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
            animate.SetBool("isRunning", true);
        } else{
            animate.SetBool("isRunning", false);
        }

        //Animate Jumping
        if(Input.GetKeyDown(KeyCode.Space)){
            animate.SetTrigger("isJumping");
        }

        //Animate Falling
        if(player.GetRigidbody().velocity.y < -1.8){
            animate.SetBool("isFalling", true);
        } else{
            animate.SetBool("isFalling", false);
        }
    }

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if(theCollision.gameObject.tag == "Enemy" && gM.livesLeft == 0){
            animate.SetTrigger("isDead");
        }
    }
}