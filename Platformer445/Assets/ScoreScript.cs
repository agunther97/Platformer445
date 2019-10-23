﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int flowersCollected = 0;
    public static int flowersPresent = 0;

    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = flowersCollected + " / " + flowersPresent;
    }
}
