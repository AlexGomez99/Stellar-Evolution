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
    // Start is called before the first frame update
    void Start()
    {
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


                if (currentDot != null)
                {
                    //checks for h matches
                    if (i > 0 && i < board.width - 1)
                    {
                       
                        GameObject rightDot = board.allDots[i + 1, j];
                        GameObject leftDot = board.allDots[i - 1, j];

                        if (rightDot != null && leftDot != null)
                        {

                            if (i > 1 && i < board.width - 2)
                            {
                                GameObject rightDotTwo = board.allDots[i + 2, j];
                                GameObject leftDotTwo = board.allDots[i - 2, j];
                                if (rightDot.tag == currentDot.tag && leftDot.tag == currentDot.tag && rightDotTwo.tag == currentDot.tag && leftDotTwo.tag == currentDot.tag && alreadyMatched1 == false)
                                {
                                    rightDot.GetComponent<Dot>().isMatched = true;
                                    rightDotTwo.GetComponent<Dot>().isMatched = true;
                                    leftDot.GetComponent<Dot>().isMatched = true;
                                    leftDotTwo.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    alreadyMatched1 = true;
                                    Debug.Log("we got a 5 match horz");
                                    Debug.Log(i + "  " + j);
                                    wasLargeHMatch = true;
                                    AM.matchSound.Play();
                                }


                                else if (rightDot.tag == currentDot.tag && leftDot.tag == currentDot.tag && rightDotTwo.tag == currentDot.tag && alreadyMatched1 == false)
                                {

                                    rightDot.GetComponent<Dot>().isMatched = true;
                                    rightDotTwo.GetComponent<Dot>().isMatched = true;
                                    leftDot.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    alreadyMatched1 = true;
                                    Debug.Log("we got a 4-1 match horz");
                                    Debug.Log(i + "  " + j);
                                    wasLargeHMatch = true;
                                    AM.matchSound.Play();

                                }
                                else if (rightDot.tag == currentDot.tag && leftDot.tag == currentDot.tag && leftDotTwo.tag == currentDot.tag && alreadyMatched1 == false)
                                {
                                    rightDot.GetComponent<Dot>().isMatched = true;
                                    leftDot.GetComponent<Dot>().isMatched = true;
                                    leftDotTwo.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    alreadyMatched1 = true;
                                    Debug.Log("we got a 4-2 match horz");
                                    Debug.Log(i + "  " + j);
                                    wasLargeHMatch = true;
                                    AM.matchSound.Play();

                                }

                                
                                
                                alreadyMatched1 = false;
                            }

                            if (!wasLargeHMatch)
                            {
                                if (rightDot.tag == currentDot.tag && leftDot.tag == currentDot.tag && alreadyMatched1 == false)
                                {
                                    rightDot.GetComponent<Dot>().isMatched = true;
                                    leftDot.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    alreadyMatched1 = true;

                                    Debug.Log("we got a 3 match horz");
                                    Debug.Log(i + "  " + j);
                                    AM.matchSound.Play();
                                }
                            }
                            wasLargeHMatch = false;
                        }
                    }
                    //checks for v matches
                    if (j > 0 && j < board.height - 1)
                    {
                        GameObject upDot = board.allDots[i, j + 1];
                        GameObject downDot = board.allDots[i, j - 1];
                            
                        if (upDot != null && downDot != null)
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
                                    Debug.Log(i + "  " + j);
                                    wasLargeVMatch = true;
                                    AM.matchSound.Play();

                                }
                                else if (upDot.tag == currentDot.tag && downDot.tag == currentDot.tag && upDotTwo.tag == currentDot.tag && alreadyMatched == false)
                                {

                                    upDot.GetComponent<Dot>().isMatched = true;
                                    upDotTwo.GetComponent<Dot>().isMatched = true;
                                    downDot.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    alreadyMatched = true;
                                    Debug.Log("we got a 4-1 match vert");
                                    Debug.Log(i + "  " + j);
                                    wasLargeVMatch = true;
                                    AM.matchSound.Play();

                                }
                                else if (upDot.tag == currentDot.tag && downDot.tag == currentDot.tag && downDotTwo.tag == currentDot.tag && alreadyMatched == false)
                                {
                                    upDot.GetComponent<Dot>().isMatched = true;
                                    downDot.GetComponent<Dot>().isMatched = true;
                                    downDotTwo.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    alreadyMatched = true;
                                    Debug.Log("we got a 4-2 match vert");
                                    Debug.Log(i + "  " + j);
                                    wasLargeVMatch = true;
                                    AM.matchSound.Play();

                                }
                                alreadyMatched = false;

                            }
                            if (!wasLargeVMatch)
                            {
                                if (upDot.tag == currentDot.tag && downDot.tag == currentDot.tag && alreadyMatched == false)
                                {
                                    upDot.GetComponent<Dot>().isMatched = true;
                                    downDot.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    Debug.Log("we got a 3 match vert");
                                    AM.matchSound.Play();

                                }
                            }
                            wasLargeVMatch = false;


                        }
                    }
                    }
                }
            }
        Debug.Log("this is the end of find matches");
        }
    }

