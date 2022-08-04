using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    [Header("Board Variables")]
    public int column;
    public int row;
    public int previousColumn;
    public int previousRow;
    public int targetX;
    public int targetY;

    public int x_offfset = 4; // This is how you change the pos of the boards x aixs
    public int y_offfset = 2; // This is how you change the pos of the boards y aixs

    public bool isMatched = false;

    private HintManager hintManager;
    private PowerUpManager powerUpManager;
    private FindMatches findMatches;
    private Board board;
    private MoveTargets moveTargets;
    private GameObject otherDot;
    

    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;


    private Vector2 tempPosition;
    public float swipeAngle = 0;
    public float swipeResist = 1f;
    public float dotZpos = -.5f;

    // Start is called before the first frame update
    void Start()
    {
        hintManager = FindObjectOfType<HintManager>();
        board = FindObjectOfType<Board>();
        powerUpManager = FindObjectOfType<PowerUpManager>();
        findMatches = FindObjectOfType<FindMatches>();
        moveTargets = FindObjectOfType<MoveTargets>();


        //targetX = (int)transform.position.x;
        //targetY = (int)transform.position.y;
        //row = targetY;
        //column = targetX;
        //previousRow = row;
        //previousColumn = column;
    }

    // Update is called once per frame
    void Update()
    {

            //FindMatches();

            //this makes the color grey during a match
        if (isMatched)
        {
            SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
            mySprite.color = new Color(1f, 1f, 1f, 0.2f);
        }
        targetX = column;
        targetY = row;
        if (Mathf.Abs(targetX - transform.position.x) > .1)
        {
            
            //Move Towards the target
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, tempPosition, .5f);
            if (board.allDots[column, row] != this.gameObject)
            {
                board.allDots[column, row] = this.gameObject;
                
               
            }
            
            //findMatches.FindAllMatches();

        }
        else
        {
            //Directly set the position
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = tempPosition;
        }
        if (Mathf.Abs(targetY - transform.position.y) > .1)
        {
            //Move Towards the target
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.Lerp(transform.position, tempPosition, .5f);
            if (board.allDots[column, row] != this.gameObject)
            {
                board.allDots[column, row] = this.gameObject;
            }

            //findMatches.FindAllMatches();
            // Debug.Log("hey");
        }
        else
        {
            //Directly set the position
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = tempPosition;
        }
    }

    public IEnumerator CheckMoveCo()
    {
        yield return new WaitForSeconds(.5f);
        if (otherDot != null)
        {
            if (!isMatched && !otherDot.GetComponent<Dot>().isMatched)
            {
                otherDot.GetComponent<Dot>().row = row;
                otherDot.GetComponent<Dot>().column = column;
                row = previousRow;
                column = previousColumn;
                yield return new WaitForSeconds(.5f);
                board.currentState = GameState.move;
            }
            else
            {
                board.DestroyMatches();

            }
            otherDot = null;
        }
    }

    private void OnMouseDown()
    {
        // Debug.Log("CLICK DOWN "+ this.gameObject);
        /*//Destroy the hint
        if (hintManager != null)
        {
            hintManager.DestroyHint();
        }*/

        moveTargets.SetTargets(gameObject);
        moveTargets.selectTargetActive = true;

        if (powerUpManager.GetComponent<PowerUpManager>().PU1) // check for all power ups here but do nothing!
        {}
        else
        if (board.currentState == GameState.move)
        {
            firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
        }
        //Debug.Log(firstTouchPosition);
    }

    //everything starts here
    private void OnMouseUp()
    {
        moveTargets.selectTargetActive = false;


        //Debug.Log("check 2");
        if (powerUpManager.GetComponent<PowerUpManager>().PU1) // check for all power ups here but do nothing!
        {
            powerUpManager.PU1Execute(row);
        }else
        if (board.currentState == GameState.move)
        {
            //Debug.Log("check 1");
            finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CalculateAngle();
            findMatches.FindAllMatches();
        }
        
    }

    // calulating the angel of the mouse direction   
    void CalculateAngle()
    {
        if (Mathf.Abs(finalTouchPosition.y - firstTouchPosition.y) > swipeResist || Mathf.Abs(finalTouchPosition.x - firstTouchPosition.x) > swipeResist)
        {
            swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x) * 180 / Mathf.PI;
            //Debug.Log("swipe angle: "+ swipeAngle);
            MovePieces();
            board.currentState = GameState.wait;
        }
        else
        {
            //Debug.Log(firstTouchPosition.y+ "    "+ finalTouchPosition.y);

            //Debug.Log("has no angle");

            board.currentState = GameState.move;
        }
    }
    //determines the postion of the mouse right,up,left,down
    void MovePieces()
    {
        if (swipeAngle > -45 && swipeAngle <= 45 && column < board.width - 1)
        {
            //Right Swipe
            otherDot = board.allDots[column + 1, row];
            previousRow = row;
            previousColumn = column;
            otherDot.GetComponent<Dot>().column -= 1;
            column += 1;
          //  Debug.Log("right");
        }
        else if (swipeAngle > 45 && swipeAngle <= 135 && row < board.height - 1)
        {
            //Up Swipe
            otherDot = board.allDots[column, row + 1];
            previousRow = row;
            previousColumn = column;
            otherDot.GetComponent<Dot>().row -= 1;
            row += 1;
           // Debug.Log("up");

        }
        else if ((swipeAngle > 135 || swipeAngle <= -135) && column > 0)
        {
            //Left Swipe
            otherDot = board.allDots[column - 1, row];
            previousRow = row;
            previousColumn = column;
            otherDot.GetComponent<Dot>().column += 1;
            column -= 1;
           // Debug.Log("left");

        }
        else if (swipeAngle < -45 && swipeAngle >= -135 && row > 0)
        {
            //Down Swipe
            otherDot = board.allDots[column, row - 1];
            previousRow = row;
            previousColumn = column;
            otherDot.GetComponent<Dot>().row += 1;
            row -= 1;
           // Debug.Log("down");

        }
        StartCoroutine(CheckMoveCo());
    }

    private void OnDestroy()
    {
        Instantiate(Resources.Load("BlowUp"),transform.position,Quaternion.identity);
    }



    /* void FindMatches()
     {
         if (column > 0 && column < board.width - 1)
         {
             GameObject leftDot1 = board.allDots[column - 1, row];
             GameObject rightDot1 = board.allDots[column + 1, row];
             if (leftDot1 != null && rightDot1 != null)
             {
                 if (leftDot1.tag == this.gameObject.tag && rightDot1.tag == this.gameObject.tag)
                 {
                     leftDot1.GetComponent<Dot>().isMatched = true;
                     rightDot1.GetComponent<Dot>().isMatched = true;
                     isMatched = true;
                 }
             }
         }
         if (row > 0 && row < board.height - 1)
         {
             {
                 GameObject upDot1 = board.allDots[column, row + 1];
                 GameObject downDot1 = board.allDots[column, row - 1];
                 if (upDot1 != null && downDot1 != null)
                 {
                     if (upDot1.tag == this.gameObject.tag && downDot1.tag == this.gameObject.tag)
                     {
                         upDot1.GetComponent<Dot>().isMatched = true;
                         downDot1.GetComponent<Dot>().isMatched = true;
                         isMatched = true;
                     }
                 }
             }
         }

     }*/
}
