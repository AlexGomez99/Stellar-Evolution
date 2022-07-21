using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//testing script 
//every frame checks the whole array of dots for horizontal and vertical matches and if it finds one it adds to a list

public class FindMatches : MonoBehaviour
{
    private Board board;
    public List<GameObject> currentMatches = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
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

                }
                else
                if (currentDot != null)
                {
                    //checks for h matches
                    if (i > 0 && i < board.width - 1)
                    {
                        GameObject rightDot = board.allDots[i + 1, j];
                        GameObject leftDot = board.allDots[i - 1, j];
                        bool alreadyMatched1 = false;
                        if (rightDot != null && leftDot != null)
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
                                    Debug.Log("we got a 5 match");
                                }


                                else if (i > 1 && i < board.width - 2 && rightDot.tag == currentDot.tag && leftDot.tag == currentDot.tag && rightDotTwo.tag == currentDot.tag && alreadyMatched1 == false)
                                {

                                    rightDot.GetComponent<Dot>().isMatched = true;
                                    rightDotTwo.GetComponent<Dot>().isMatched = true;
                                    leftDot.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    alreadyMatched1 = true;
                                    //Debug.Log(i + "," + j);
                                    Debug.Log("we got a 4 match");
                                }
                                /*else if (i > 1 && i < board.width - 2 && rightDot.tag == currentDot.tag && leftDot.tag == currentDot.tag && leftDotTwo.tag == currentDot.tag && alreadyMatched1 == false)
                                {
                                    rightDot.GetComponent<Dot>().isMatched = true;
                                    leftDot.GetComponent<Dot>().isMatched = true;
                                    leftDotTwo.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    alreadyMatched1 = true;
                                    // Debug.Log("we got a 4 match");

                                }*/

                            }

                            if (rightDot.tag == currentDot.tag && leftDot.tag == currentDot.tag && alreadyMatched1 == false)
                            {
                                rightDot.GetComponent<Dot>().isMatched = true;
                                leftDot.GetComponent<Dot>().isMatched = true;
                                currentDot.GetComponent<Dot>().isMatched = true;
                                Debug.Log("we got a 3 match");
                               

                                /*                            if (!currentMatches.Contains(rightDot))
                                                            {
                                                                currentMatches.Add(rightDot);
                                                            }

                                                            if (!currentMatches.Contains(leftDot))
                                                            {
                                                                currentMatches.Add(leftDot);
                                                            }

                                                            if (!currentMatches.Contains(currentDot))
                                                            {
                                                                currentMatches.Add(currentDot);
                                                            }*/


                            }
                        }
                    }
                        //checks for v matches
                        if (j > 0 && j < board.height - 1)
                        {
                            GameObject upDot = board.allDots[i, j + 1];
                            GameObject downDot = board.allDots[i, j - 1];
                            bool alreadyMatched = false;
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
                                    Debug.Log("match 5");
                                    // Debug.Log("we got a 5 match");
                                }


                                    else if (j > 1 && j < board.height - 2 && upDot.tag == currentDot.tag && downDot.tag == currentDot.tag && upDotTwo.tag == currentDot.tag && alreadyMatched == false)
                                    {

                                        upDot.GetComponent<Dot>().isMatched = true;
                                        upDotTwo.GetComponent<Dot>().isMatched = true;
                                        downDot.GetComponent<Dot>().isMatched = true;
                                        currentDot.GetComponent<Dot>().isMatched = true;
                                        alreadyMatched = true;
                                    Debug.Log("match 4-1");
                                    //Debug.Log(i + "," + j);
                                    //Debug.Log("we got a 4 match");
                                }
                                    /*else if (j > 1 && j < board.height - 2 && upDot.tag == currentDot.tag && downDot.tag == currentDot.tag && downDotTwo.tag == currentDot.tag && alreadyMatched == false)
                                    {
                                        upDot.GetComponent<Dot>().isMatched = true;
                                        downDot.GetComponent<Dot>().isMatched = true;
                                        downDotTwo.GetComponent<Dot>().isMatched = true;
                                        currentDot.GetComponent<Dot>().isMatched = true;
                                        alreadyMatched = true;
                                    Debug.Log("match 4-2");
                                    // Debug.Log("we got a 4 match");

                                }*/

                                }

                                if (upDot.tag == currentDot.tag && downDot.tag == currentDot.tag && alreadyMatched == false)
                                {
                                    upDot.GetComponent<Dot>().isMatched = true;
                                    downDot.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    Debug.Log("match 3");

                                    /*                            if (!currentMatches.Contains(upDot))
                                                                {
                                                                    currentMatches.Add(upDot);
                                                                }

                                                                if (!currentMatches.Contains(downDot))
                                                                {
                                                                    currentMatches.Add(downDot);
                                                                }

                                                                if (!currentMatches.Contains(currentDot))
                                                                {
                                                                    currentMatches.Add(currentDot);
                                                                }*/

                                }




                            }
                        }
                    }
                }
            }
        }
    }
