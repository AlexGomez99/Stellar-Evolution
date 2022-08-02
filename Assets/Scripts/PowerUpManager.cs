using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private Board board;

    public bool PU1 = true;
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PU1ToggleOn()
    {
        if(PU1 == true){
            PU1 = false;
        }
        else{
            PU1 = true;
        }
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
