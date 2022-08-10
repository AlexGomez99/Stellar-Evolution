using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargets : MonoBehaviour
{

    public GameObject selectTarget;
    public GameObject moveTarget;
    public GameObject dot;
    public GameObject otherDot;

    private Board board;

    public bool selectTargetActive = false;
    public bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
        selectTarget = GameObject.FindGameObjectWithTag("select target");
        moveTarget = GameObject.FindGameObjectWithTag("move target");
    }

    // Update is called once per frame
    void Update()
    {
        if (selectTargetActive)
        {
            SelectTargets();
        }
        else
        {
            selectTarget.SetActive(false);
            moveTarget.SetActive(false);
            canMove = false;
            //selectTarget.transform.position = new Vector3(1000, 1000, 1000);
            //moveTarget.transform.position = new Vector3(1000, 1000, 1000);
        }
    }

    public void SetTargets(GameObject targetDot)
    {
        dot = targetDot;
    }

    public void SelectTargets()
    {
        int column = dot.GetComponent<Dot>().column;
        int row = dot.GetComponent<Dot>().row;
        selectTarget.SetActive(true);

        selectTarget.transform.position = dot.transform.position;
        Vector3 temp;
        temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float dist = Vector2.Distance(temp, dot.transform.position);


        if (dist > 1.08f)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }

        float tempAngle = Mathf.Atan2(temp.y - dot.transform.position.y, temp.x - dot.transform.position.x) * 180 / Mathf.PI;

        if (canMove)
        {
            if (tempAngle > -45 && tempAngle <= 45 && column < board.width - 1)
            {
                //Right Swipe
                otherDot = board.allDots[column + 1, row];
                moveTarget.SetActive(true);
                moveTarget.transform.position = otherDot.transform.position;
            }
            else if (tempAngle > 45 && tempAngle <= 135 && row < board.height - 1)
            {
                //Up Swipe
                otherDot = board.allDots[column, row + 1];
                moveTarget.SetActive(true);
                moveTarget.transform.position = otherDot.transform.position;
                // Debug.Log("up");

            }
            else if ((tempAngle > 135 || tempAngle <= -135) && column > 0)
            {
                //Left Swipe
                otherDot = board.allDots[column - 1, row];
                moveTarget.SetActive(true);
                moveTarget.transform.position = otherDot.transform.position;
                // Debug.Log("left");

            }
            else if (tempAngle < -45 && tempAngle >= -135 && row > 0)
            {
                //Down Swipe
                otherDot = board.allDots[column, row - 1];
                moveTarget.SetActive(true);
                moveTarget.transform.position = otherDot.transform.position;
                // Debug.Log("down");

            }
            
        }
        else
        {
            moveTarget.SetActive(false);
        }
    }
}
