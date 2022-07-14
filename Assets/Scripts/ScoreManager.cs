using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    public int score;


    


    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int amountToIncrease)
    {
        //Debug.Log(amountToIncrease);
        score += amountToIncrease;
        scoreText.text = "" + score;

    }
}
