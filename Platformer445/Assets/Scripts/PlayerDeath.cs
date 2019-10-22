using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    //Stores  object
    GameObject gO;
    //Calls GameManager script
    GameManager gM;

    public Transform getSpawnPos;

    void Update() 
    {
        InitPlayerDeathChecks();
    }

    public void InitPlayerDeathChecks()
    {
        //Stores GameManager object to gO
        gO= GameObject.Find("GameManager");
        //Calls GameManager script from GameManager object
        gM = gO.GetComponent<GameManager>();

        getSpawnPos.position = gM.spawnPos.position;
    }

    void OnCollisionEnter2D(Collision2D theCollsion)
    {
        if(theCollsion.gameObject.tag == "Player"){
            Debug.Log("Sub1");
            theCollsion.transform.position = gM.spawnPos.position;
            gM.livesLeft--;
        }
    }
}