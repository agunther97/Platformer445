using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    //Grappling Hook Components
    Vector3 mousePos;
    public LineRenderer hookLine;
    DistanceJoint2D hook;
    RaycastHit2D hookHit;
    public float hookReach = 10f;
    public LayerMask mask;
    public float step = 0.02f;


    //Animator for grappling hook
    private Animator grappleAnimation;

    void Start()
    {
         InitHookChecks();
    }

    // Update is called once per frame
    void Update()
    {
        Grapple();
    }

    //Checks that need to be set at Start()
    public void InitHookChecks()
    {
        hook = GetComponent<DistanceJoint2D>();
        hook.enabled = false; hookLine.enabled = false;

        grappleAnimation = GetComponent<Animator>(); 
    }

    public void Grapple()
    {
        if(hook.distance > .5f){
            hook.distance -= step;
        } else{
            hookLine.enabled = false; hook.enabled = false;
        }

        if(Input.GetMouseButtonDown(0)){
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            hookHit = Physics2D.Raycast(transform.position, mousePos - transform.position, hookReach, mask);
            
            //This could possibly be used to interact with enemies, see doc for further notes
            if(hookHit.collider != null && hookHit.collider.gameObject.GetComponent<Rigidbody2D>() != null){
                hook.enabled = true;

                //Connects the grappling hook to the cursor placement, versus the center of the object we collided with
                Vector2 connectPoint =hookHit.point - new Vector2(hookHit.collider.transform.position.x,hookHit.collider.transform.position.y);
				connectPoint.x = connectPoint.x / hookHit.collider.transform.localScale.x;
				connectPoint.y = connectPoint.y / hookHit.collider.transform.localScale.y;
                hook.connectedAnchor = connectPoint;
                
                hook.connectedBody = hookHit.collider.gameObject.GetComponent<Rigidbody2D>();
                hook.distance = Vector2.Distance(transform.position, hookHit.point);

                hookLine.enabled = true;
                hookLine.SetPosition(0, transform.position);
                hookLine.SetPosition(1, hook.connectedBody.transform.TransformPoint( hook.connectedAnchor));
                hookLine.GetComponent<HookRatio>().grabPosition = hookHit.point;
                
                grappleAnimation.SetTrigger("isGrappling");
            }
        }

        if(Input.GetMouseButton(0)){
            hookLine.SetPosition(0, transform.position);
        }
        if(Input.GetMouseButtonUp(0)){
            hook.enabled = false; hookLine.enabled = false;
        }
    }
}
