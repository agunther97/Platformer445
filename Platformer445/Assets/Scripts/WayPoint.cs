using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    GameObject gO;

    GameManager gM;
    // Start is called before the first frame update
    void Start()
    {
        InitWaypointChecks();
    }

    public void InitWaypointChecks()
    {
        //Stores GameManager object to gO //Calls GameManager script from GameManager object
        gO= GameObject.Find("GameManager"); gM = gO.GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D theCollision)
    {
        if(theCollision.gameObject.tag == "Player"){
            gM.spawnPos.position = transform.position;
        }
    }
}
