using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform spawnPos;

    public int livesLeft = 4;
    
    GameObject Player;

    Vector3 tempValue;

    public static bool isPaused;

    [SerializeField]
    private GameObject gameOverUI;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        Player.transform.position = spawnPos.transform.position;
        gameOverUI.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
