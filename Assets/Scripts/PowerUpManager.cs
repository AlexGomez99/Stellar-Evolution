using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    
    public GameObject daButton;
    private Board board;
    private ScoreManager scoreManager;
    private AudioManager AM;
    public bool soundThing = false;
    public bool PU1 = true;
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
        scoreManager = FindObjectOfType<ScoreManager>();
        AM = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if(scoreManager.powerUp >= 500 && soundThing == false )
        {
            
            daButton.SetActive(true);
            AM.coinSound.Play();
            soundThing = true;
        }
    }
    public void PU1ToggleOn()
    {
        PU1 = true;
        daButton.SetActive(false);
        scoreManager.powerUp = 0;
        soundThing = false;
        AM.magneticAnomaly1.Play();
        
    }
    public void PU1Execute(int row)
    {
        for (int i = 0; i < board.width; i++)
        {
            board.allDots[i, row].GetComponent<Dot>().isMatched = true;
        }
        board.DestroyMatches();
        AM.bloop2.Play();
    }
}
