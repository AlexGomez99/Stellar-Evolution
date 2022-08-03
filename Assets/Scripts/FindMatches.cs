using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//testing script 
//every frame checks the whole array of dots for horizontal and vertical matches and if it finds one it adds to a list

public class FindMatches : MonoBehaviour
{
    private Board board;
    private AudioManager AM;
    public List<GameObject> currentMatches = new List<GameObject>();
    bool alreadyMatched1 = false;
    bool alreadyMatched = false;
    public bool wasLargeHMatch;
    public bool wasLargeVMatch;
    private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        AM = FindObjectOfType<AudioManager>();
        board = FindObjectOfType<Board>();
    }

    public void FindAllMatches()
    {
        StartCoroutine(FindAllMatchesCo());
    }

    private IEnumerator FindAllMatchesCo()
    {
        yield return new WaitForSeconds(.2f);
        for (int i = 0; i < board.width; i++)
        {
            for (int j = 0; j < board.height; j++)
            {

                GameObject currentDot = board.allDots[i, j];
                //Debug.Log(i + "  " + j + " :"+currentDot.tag) ;

                if(currentDot.tag == "Dust Clump")
                {

                }else
                if (currentDot != null && currentDot.GetComponent<Dot>().isMatched != true)
                {
                    //checks for h matches
                    if (i > 0 && i < board.width - 1)
                    {
                       
                        GameObject rightDot = board.allDots[i + 1, j];
                        GameObject leftDot = board.allDots[i - 1, j];

                        if (rightDot != null && leftDot != null && currentDot.GetComponent<Dot>().isMatched != true)
                        {

                            if (i > 1 && i < board.width - 2)
                            {
                                GameObject rightDotTwo = board.allDots[i + 2, j];
                                GameObject leftDotTwo = board.allDots[i - 2, j];
                                if (rightDot.tag == currentDot.tag && leftDot.tag == currentDot.tag && rightDotTwo.tag == currentDot.tag && leftDotTwo.tag == currentDot.tag)
                                {
                                    rightDot.GetComponent<Dot>().isMatched = true;
                                    rightDotTwo.GetComponent<Dot>().isMatched = true;
                                    leftDot.GetComponent<Dot>().isMatched = true;
                                    leftDotTwo.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    alreadyMatched1 = true;
                                    Debug.Log("we got a 5 match horz");
                                    scoreManager.IncreaseScore(50);
                                    wasLargeHMatch = true;
                                    AM.matchSound.Play();
                                }
                            }
                        }
                    }
                }
            }
        }

        for (int i = 0; i < board.width; i++)
        {
            for (int j = 0; j < board.height; j++)
            {

                GameObject currentDot = board.allDots[i, j];
                //Debug.Log(i + "  " + j + " :"+currentDot.tag) ;

                if(currentDot.tag == "Dust Clump")
                {

                }else{
                    if (currentDot != null && currentDot.GetComponent<Dot>().isMatched != true) 
                {
                    //checks for h matches
                    if (i > 0 && i < board.width - 1)
                    {
                       
                        GameObject rightDot = board.allDots[i + 1, j];
                        GameObject leftDot = board.allDots[i - 1, j];

                        if (rightDot != null && leftDot != null && currentDot.GetComponent<Dot>().isMatched != true)
                        {

                            if (i > 0 && i < board.width - 2)
                            {
                                GameObject rightDotTwo = board.allDots[i + 2, j];
                                if (rightDot.tag == currentDot.tag && leftDot.tag == currentDot.tag && rightDotTwo.tag == currentDot.tag)
                                {
                                    rightDot.GetComponent<Dot>().isMatched = true;
                                    rightDotTwo.GetComponent<Dot>().isMatched = true;
                                    leftDot.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    alreadyMatched1 = true;
                                    Debug.Log("we got a 4 match horz");
                                    scoreManager.IncreaseScore(25);
                                    wasLargeHMatch = true;
                                    AM.matchSound.Play();
                                }
                            }
                        }
                    }
                }
                }
                
            }
        }
        for (int i = 0; i < board.width; i++)
        {
            for (int j = 0; j < board.height; j++)
            {

                GameObject currentDot = board.allDots[i, j];
                //Debug.Log(i + "  " + j + " :"+currentDot.tag) ;

                if(currentDot.tag == "Dust Clump")
                {

                }else{
                    if (currentDot != null && currentDot.GetComponent<Dot>().isMatched != true)
                {
                    if (i > 0 && i < board.width - 1)
                    {
                       
                        GameObject rightDot = board.allDots[i + 1, j];
                        GameObject leftDot = board.allDots[i - 1, j];

                        if (rightDot != null && leftDot != null )
                        {

                            
                                
                                if (rightDot.tag == currentDot.tag && leftDot.tag == currentDot.tag)
                                {
                                    rightDot.GetComponent<Dot>().isMatched = true;
                                    leftDot.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    Debug.Log("we got a 3 match horz");
                                    scoreManager.IncreaseScore(15);
                                    AM.matchSound.Play();
                                    
                                }
                            
                        }
                    }
                }
                }
                
            }
        }


                               
                    //checks for v matches
                    for (int i = 0; i < board.width; i++)
        {
            for (int j = 0; j < board.height; j++)
            {
                GameObject currentDot = board.allDots[i, j];
                if (currentDot != null && currentDot.GetComponent<Dot>().isMatched != true)
                {
                    if (j > 0 && j < board.height - 1)
                    {
                        
                        GameObject upDot = board.allDots[i, j + 1];
                        GameObject downDot = board.allDots[i, j - 1];
                            
                        if (upDot != null && downDot != null  && currentDot.GetComponent<Dot>().isMatched != true)
                        {
                                
                            if (j > 1 && j < board.height - 2)
                            {
                                GameObject upDotTwo = board.allDots[i, j + 2];
                                GameObject downDotTwo = board.allDots[i, j - 2];
                                if (upDot.tag == currentDot.tag && downDot.tag == currentDot.tag && upDotTwo.tag == currentDot.tag && downDotTwo.tag == currentDot.tag)
                                {
                                    upDot.GetComponent<Dot>().isMatched = true;
                                    upDotTwo.GetComponent<Dot>().isMatched = true;
                                    downDot.GetComponent<Dot>().isMatched = true;
                                    downDotTwo.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    alreadyMatched = true;
                                    Debug.Log("we got a 5 match vert");
                                    scoreManager.IncreaseScore(50);
                                    wasLargeVMatch = true;
                                    AM.matchSound.Play();

                                            }

                                            }
                                            }
                                            }
                                            }
                                            }
        }

        for (int i = 0; i < board.width; i++)
        {
            for (int j = 0; j < board.height; j++)
            {
                GameObject currentDot = board.allDots[i, j];
                if (currentDot != null && currentDot.GetComponent<Dot>().isMatched != true)
                {
                    if (j > 0 && j < board.height - 1)
                    {
                        
                        GameObject upDot = board.allDots[i, j + 1];
                        GameObject downDot = board.allDots[i, j - 1];
                            
                        if (upDot != null && downDot != null && currentDot.GetComponent<Dot>().isMatched != true)
                        {
                                
                            if (j > 0 && j < board.height - 2)
                            {
                                GameObject upDotTwo = board.allDots[i, j + 2];
                                
                                if (upDot.tag == currentDot.tag && downDot.tag == currentDot.tag && upDotTwo.tag == currentDot.tag)
                                {
                                    upDot.GetComponent<Dot>().isMatched = true;
                                    upDotTwo.GetComponent<Dot>().isMatched = true;
                                    downDot.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    alreadyMatched = true;
                                    Debug.Log("we got a 4 match vert");
                                    scoreManager.IncreaseScore(25);
                                    wasLargeVMatch = true;
                                    AM.matchSound.Play();

                                            }

                                            }
                                            }
                                            }
                                            }
                                            }
        }
for (int i = 0; i < board.width; i++)
        {
            for (int j = 0; j < board.height; j++)
            {
                GameObject currentDot = board.allDots[i, j];
                if (currentDot != null && currentDot.GetComponent<Dot>().isMatched != true)
                {
                    if (j > 0 && j < board.height - 1)
                    {
                        
                        GameObject upDot = board.allDots[i, j + 1];
                        GameObject downDot = board.allDots[i, j - 1];
                            
                        if (upDot != null && downDot != null && currentDot.GetComponent<Dot>().isMatched != true)
                        {
                                
                            
                                if (upDot.tag == currentDot.tag && downDot.tag == currentDot.tag)
                                {
                                    upDot.GetComponent<Dot>().isMatched = true;
                                    
                                    downDot.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    alreadyMatched = true;
                                    Debug.Log("we got a 3 match vert");
                                    scoreManager.IncreaseScore(15);
                                    wasLargeVMatch = true;
                                    AM.matchSound.Play();

                                            }

                                            }
                                            }
                                            }
                                            }
                                            }
    }
                            }

