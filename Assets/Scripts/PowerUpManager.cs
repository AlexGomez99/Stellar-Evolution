using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    
    public GameObject daButton;
    private Board board;
    private ScoreManager scoreManager;

    public bool PU1 = true;
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreManager.powerUp >= 500)
        {
            
            daButton.SetActive(true);
        }
    }
    public void PU1ToggleOn()
    {
        PU1 = true;
        scoreManager.powerUp = 0;
        daButton.SetActive(false);
    }
    public void PU1Execute(int row)
    {
        for (int i = 0; i < board.width; i++)
        {
            board.allDots[i, row].GetComponent<Dot>().isMatched = true;
        }
        board.DestroyMatches();
    }
}
