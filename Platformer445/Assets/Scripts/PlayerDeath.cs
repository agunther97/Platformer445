using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Transform spawnPos;

    //Stores  object
    GameObject gO;
    //Calls GameManager script
    GameManager gM;


    // Start is called before the first frame update
    void Start()
    {
        InitPlayerDeathChecks();
    }

    public void InitPlayerDeathChecks()
    {
        //Stores GameManager object to gO
        gO= GameObject.Find("GameManager");
        //Calls GameManager script from GameManager object
        gM = gO.GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D theCollsion)
    {
        if(theCollsion.gameObject.tag == "Player"){
            Debug.Log("Sub1");
            theCollsion.transform.position = spawnPos.position;
            gM.livesLeft--;
        }
    }
}