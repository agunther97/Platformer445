using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int livesLeft = 4;
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
        }
    }
}
