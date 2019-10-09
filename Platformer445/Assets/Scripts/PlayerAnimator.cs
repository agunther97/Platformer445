using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAnimator : MonoBehaviour
{
    private Animator animate;

    private PlayerController pc;


    void Start(){
        animate = GetComponent<Animator>();
        pc = GetComponent<PlayerController>();
    }

    void Update(){
        AnimateControls();   
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
        if(pc.GetRigidbody().velocity.y < -1.8){
            animate.SetBool("isFalling", true);
        } else{
            animate.SetBool("isFalling", false);
        }
    }
}