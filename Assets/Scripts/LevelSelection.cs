using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{

    int counter = 1;

    GameObject level;

    [Header("Object References")]
    public Text levelNumber;
    
    Image myImageComponent;
    public Sprite firstLevel;
    public Sprite secondLevel;
    public Sprite thirdLevel;
    public Sprite fourthLevel;
    public Sprite fifthLevel;
    public Sprite sixthLevel;
    public Sprite seventhLevel;
    public Sprite eightLevel;
    public Sprite ninthLevel;
    public Sprite tenthLevel;

    public void Awake()
    {
        myImageComponent = GetComponent<Image>();
    }

    public void Update()
    {
        LevelSelector();
    }

    public void plusCounter()
    {
        counter++;
        if(counter > 10){
            counter--;
        }
        Debug.Log(counter);
    }

    public void subCounter()
    {
        counter--;
        if(counter < 1){
            counter++;
        }
        Debug.Log(counter);
    }

    public void LevelSelected(){
        LoadLevel("Level " + counter);
    }
     public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LevelSelector()
    {
        counter.ToString();
        levelNumber.text = "Level " + counter.ToString();

        if(counter == 1){
            myImageComponent.sprite = firstLevel;
        }
        if(counter == 2){
            myImageComponent.sprite = secondLevel;
        }if(counter == 3){
            myImageComponent.sprite = thirdLevel;
        }if(counter == 4){
            myImageComponent.sprite = fourthLevel;
        }if(counter == 5){
            myImageComponent.sprite = fifthLevel;
        }if(counter == 6){
            myImageComponent.sprite = sixthLevel;
        }if(counter == 7){
            myImageComponent.sprite = seventhLevel;
        }if(counter == 8){
            myImageComponent.sprite = eightLevel;
        }if(counter == 9){
            myImageComponent.sprite = ninthLevel;
        }if(counter == 10){
            myImageComponent.sprite = tenthLevel;
        }
    }
}