using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    wait,
    move
}

public class Board : MonoBehaviour
{
    public GameState currentState = GameState.move;
    public int width;
    public int height;
    public int offSet;
    public float dotSize;
    public float dotZPos = -.5f;
    public float totalScore = 0.0f;
    

    public GameObject tilePrefab;
    public GameObject[] dots;
    private BackgroundTile[,] allTiles;
    public GameObject[,] allDots;
    private FindMatches findMatches;
    public float basePieceValue;
    private float streakValue = 1.0f;
    private ScoreManager scoreManager;
    private PowerUpManager powerUpManager;
    //private bool specialSpawn = false;

    public int count = 0;
    public int PUcount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
        powerUpManager = FindObjectOfType<PowerUpManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        findMatches = FindObjectOfType<FindMatches>();
        allTiles = new BackgroundTile[width, height];
        allDots = new GameObject[width, height];
        
    }

    public void SetUp()
    {
        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                //Vector2 tempPosition = new Vector2(1000000, -100000);
                Vector2 tempPosition = new Vector2(i, j+offSet);
                Vector2 tilePosition = new Vector2(i, j);

                //Vector2 tilePosition = new Vector2(i, j);
                GameObject backgroundTile = Instantiate(tilePrefab, tilePosition, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "( " + i + ", " + j + " )";
                int dotToUse = DotToChoose();
                
                int maxIterations = 0;
                while(MatchesAt(i, j, dots[dotToUse]) && maxIterations < 100)
                {
                    dotToUse = DotToChoose();
                    maxIterations++;
                    //Debug.Log(maxIterations);
                }
                maxIterations = 0;

                GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
                dot.GetComponent<Dot>().row = j;
                dot.GetComponent<Dot>().column = i;
                //dot.transform.parent = this.transform;
                dot.name = "( " + i + ", " + j + " )";
                //dot.transform.localScale = dot.transform.localScale / dotSize;
                allDots[i, j] = dot;
            }
        }
        DestroyMatches();
    }

    private bool MatchesAt(int column, int row, GameObject piece)
    {
        if(column > 1 && row > 1)
        {
            if(allDots[column - 1, row].tag == piece.tag && allDots[column - 2, row].tag == piece.tag)
            {
                return true;
            }
            if (allDots[column, row - 1].tag == piece.tag && allDots[column - 2, row - 2].tag == piece.tag)
            {
                return true;
            }
        }else if(column <= 1 || row <= 1)
        {
            if(row > 1)
            {
                if(allDots[column, row - 1].tag == piece.tag && allDots[column, row-2].tag == piece.tag)
                {
                    return true;
                }
            }
            if (column > 1)
            {
                if (allDots[column - 1, row].tag == piece.tag && allDots[column - 2, row].tag == piece.tag)
                {
                    return true;
                }
            }
        }

        return false;
    }

    //this is the function destroys game objects in which they are matched
    private void DestroyMatchesAt(int column, int row)
    {
       

        // Vector2 tempPosition = new Vector2(column, row + offSet);

        if (allDots[column, row].GetComponent<Dot>().isMatched)
        {
            if (!powerUpManager.PU1)
            {
                count++;
            }
            else
            {
                PUcount++;
            }
            
            //  findMatches.currentMatches.Remove(allDots[column, row]);
            Destroy(allDots[column, row]);
            
            



            //Debug.Log(count);

           
            
            if(count == 4)
            {
                streakValue = 1.25f;
            }
            if (count == 5)
            {
                streakValue = 2.0f;
            }
            basePieceValue = 5;
            if (allDots[column, row].tag == "Special Helium")
            {
                //Debug.Log("Special Helium");
                basePieceValue += 10;


            }

            if (count == 4 && allDots[column, row].tag == "Special Helium")
            {
                Vector2 tempPosition = new Vector2(column, row + offSet);
                GameObject piece = Instantiate(dots[0], tempPosition, Quaternion.identity);
                allDots[column, row] = piece;
                piece.GetComponent<Dot>().row = row;
                piece.GetComponent<Dot>().column = column;
            }

            else if (count == 4)
            {

                Vector2 tempPosition = new Vector2(column, row + offSet);
                GameObject piece = Instantiate(dots[1], tempPosition, Quaternion.identity);
                allDots[column, row] = piece;
                piece.GetComponent<Dot>().row = row;
                piece.GetComponent<Dot>().column = column;
            }

            
            totalScore += basePieceValue;
            if (count < 4)
            {
                allDots[column, row] = null;
            }
            
        }
    }

    public void DestroyMatches()
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                if(allDots[i, j] != null)
                {
                    
                    
                    DestroyMatchesAt(i, j);

                }
            }
        }
        // Debug.Log(count);

        /*Debug.Log(totalScore);
        Debug.Log(streakValue);
        Debug.Log(totalScore * streakValue);
        scoreManager.IncreaseScore(totalScore * streakValue);
        
        totalScore = 0.0f;
        streakValue = 0;*/
        StartCoroutine(DecreaseRowCo());
        if(PUcount == 7)
        {
            powerUpManager.PU1 = false;
            PUcount = 0;
        }
        
    }

    private IEnumerator DecreaseRowCo()
    {
        int nullCount = 0;
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                if(allDots[i, j] == null)
                {
                    nullCount++;
                }else if(nullCount > 0)
                {
                    allDots[i, j].GetComponent<Dot>().row -= nullCount;
                    allDots[i, j] = null;
                }
            }
            nullCount = 0;
        }
        yield return new WaitForSeconds(.4f);
        StartCoroutine(FillBoardCo());
        findMatches.FindAllMatches();
    }

    private void RefillBoard()
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                if(allDots[i, j] == null)
                {
                    Vector2 tempPosition = new Vector2(i, j + offSet);
                    int dotToUse = DotToChoose();
                   // Debug.Log(count);

                        GameObject piece = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
                        allDots[i, j] = piece;
                        piece.GetComponent<Dot>().row = j;
                        piece.GetComponent<Dot>().column = i;

                    count = 0;


                }
                
            }
        }
    }

    private bool MatchesOnBoard()
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                if(allDots[i, j] != null)
                {
                    if(allDots[i, j].GetComponent<Dot>().isMatched)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private IEnumerator FillBoardCo()
    {
        RefillBoard();
        yield return new WaitForSeconds(.5f);

        while (MatchesOnBoard())
        {
            streakValue++;
            yield return new WaitForSeconds(.5f);
            DestroyMatches();
        }
        yield return new WaitForSeconds(.5f);

        if (IsDeadlocked())
        {
            Debug.Log("Deadlocked!!!");
            if (SceneManager.GetActiveScene().name == "Level 1" && scoreManager.score > 3499) 
            {
                SceneManager.LoadScene(sceneName: "level 2");
            }
            else if (SceneManager.GetActiveScene().name == "Level 2" && scoreManager.score > 4199)
            {
                SceneManager.LoadScene(sceneName: "level 3");
            }
            else if (SceneManager.GetActiveScene().name == "Level 3" && scoreManager.score > 4999)
            {
                Application.Quit();
            }

        }
        else
        {
            //Debug.Log("the game continues");  
        }
        currentState = GameState.move;
        streakValue = 1;
    }

    private void SwitchPieces(int column, int row, Vector2 direction)
    {
        //Take the second piece and save it in a holder
        GameObject holder = allDots[column + (int)direction.x, row + (int)direction.y] as GameObject;
        //Switching the first dot to be the second position
        allDots[column + (int)direction.x, row + (int)direction.y] = allDots[column, row];
        //Set the first dot to be the second dot
        allDots[column, row] = holder;
    }

    private bool CheckForMatches()
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < width; j++)
            {
                if(allDots[i, j] != null)
                {
                    //Make sure that one and two to the right are in the board
                    if (i < width - 2)
                    {
                        //Check if the dots to the right and two to the right exist
                        if (allDots[i + 1, j] != null && allDots[i + 2, j] != null)
                        {
                            if (allDots[i + 1, j].tag == allDots[i, j].tag && allDots[i + 2, j].tag == allDots[i, j].tag && allDots[i,j].tag != "Dust Clump")
                            {
                                return true;
                            }
                        }
                    }
                    if (j < height - 2)
                    {
                        //Check if the dots above exist
                        if (allDots[i, j + 1] != null && allDots[i, j + 2] != null)
                        {
                            if (allDots[i, j + 1].tag == allDots[i, j].tag && allDots[i, j + 2].tag == allDots[i, j].tag && allDots[i, j].tag != "Dust Clump")
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }
        return false;
    }

    public bool SwitchAndCheck(int column, int row, Vector2 direction)
    {
        SwitchPieces(column, row, direction);
        if (CheckForMatches())
        {
            SwitchPieces(column, row, direction);
            return true;
        }
        SwitchPieces(column, row, direction);
        return false;
    }

    private bool IsDeadlocked()
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                if(allDots[i, j] != null)
                {
                    if(i < width - 1)
                    {
                        if(SwitchAndCheck(i, j, Vector2.right))
                        {
                            return false;
                        }
                    }
                    if(j < height - 1)
                    {
                        if(SwitchAndCheck(i, j, Vector2.up))
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return true;
    }

    private int DotToChoose()
    {
        
        int dotNum = 0;
        dotNum = Random.Range(0, 70);
        if(dotNum < 1)
        {
            return 0;
        }
        else
        {

            dotNum = Random.Range(0, 100);
            if(dotNum < 5)
            {
                return 1;
            }
            else
            {
                dotNum = Random.Range(2, 6);
                return dotNum;
            }
        }
            

    }
}
