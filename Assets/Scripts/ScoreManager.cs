using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    public float score;
    public FillBar fillBar;
    public float powerUp;


    private void Start()
    {
        fillBar = FindObjectOfType<FillBar>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void IncreaseScore(float amountToIncrease)
    {
        //Debug.Log(amountToIncrease);
        score += amountToIncrease;
        powerUp += amountToIncrease;
        scoreText.text = "" + (int)score;
        fillBar.ChangeFillBar(score);

    }
}
