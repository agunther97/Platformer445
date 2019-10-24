using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int livesLeft = 4;

    public Transform spawnPos;

    [SerializeField]
    private GameObject gameOverUI;

    GameObject Player;

    void Awake(){
        gameOverUI.SetActive(false);
        Player = GameObject.Find("Player");
        Player.transform.position = spawnPos.transform.position;
    }

    void Update() 
    {
        GameOver();
    }

    private void GameOver(){
        if(livesLeft == 0){
            Debug.Log("GameOver");
            gameOverUI.SetActive(true);
        }
    }
}