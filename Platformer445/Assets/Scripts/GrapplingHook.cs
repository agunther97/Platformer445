﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public LineRenderer line;
    DistanceJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance = 10f;
    public LayerMask mask;

    public float step = 0.02f;


    //Animator for grappling hook
    private Animator grappleAnimation;
    // Start is called before the first frame update


    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;

        grappleAnimation = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        Grapple();
    }

    public void Grapple(){
        
        if(joint.distance > .5f){
            joint.distance -= step;
        } else{
            line.enabled = false;
            joint.enabled = false;
        }

        if(Input.GetMouseButtonDown(0)){
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;

            hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);
            
            //This could possibly be used to interact with enemies, see doc for further notes
            if(hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null){
                joint.enabled = true;

                //Connects the grappling hook to the cursor placement, versus the center of the object we collided with
                Vector2 connectPoint =hit.point - new Vector2(hit.collider.transform.position.x,hit.collider.transform.position.y);
				connectPoint.x = connectPoint.x / hit.collider.transform.localScale.x;
				connectPoint.y = connectPoint.y / hit.collider.transform.localScale.y;
                joint.connectedAnchor = connectPoint;
                
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.distance = Vector2.Distance(transform.position, hit.point);

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, joint.connectedBody.transform.TransformPoint( joint.connectedAnchor));
                line.GetComponent<RopeRatio>().grabPosition = hit.point;
                
                grappleAnimation.SetTrigger("isGrappling");
            }
        }

        if(Input.GetMouseButton(0)){
            line.SetPosition(0, transform.position);
        }

        if(Input.GetMouseButtonUp(0)){
            joint.enabled = false;
            line.enabled = false;
        }
    }
}
