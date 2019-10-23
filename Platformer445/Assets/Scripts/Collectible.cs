using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    Canvas messageCanvas;

    void Start()
    {
        messageCanvas.enabled = false;
        ScoreScript.flowersPresent++;
    }

    // When a player enters the collider for the flower, it enables the collected image, destroys the flower, and raises the score
    void OnTriggerEnter2D(Collider2D theCollision)
    {
        if (theCollision.gameObject.tag == "Player")
        {
            ScoreScript.flowersCollected++;
            messageCanvas.enabled = true;
            Destroy(gameObject);
        }
    }
}