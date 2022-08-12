using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

                }else{
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
                                if (rightDot.tag == currentDot.tag && leftDot.tag == currentDot.tag && rightDotTwo.tag == currentDot.tag && leftDotTwo.tag == currentDot.tag)
                                {
                                    rightDot.GetComponent<Dot>().isMatched = true;
                                    rightDotTwo.GetComponent<Dot>().isMatched = true;
                                    leftDot.GetComponent<Dot>().isMatched = true;
                                    leftDotTwo.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    alreadyMatched1 = true;
                                    Debug.Log("we got a 5 match horz");
                                    if(currentDot.tag == "Special Helium"){
                                        scoreManager.IncreaseScore(200);
                                    }else{
                                        scoreManager.IncreaseScore(50);
                                    }
                                    wasLargeHMatch = true;
                                    if(SceneManager.GetActiveScene().name == "Level 1")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.bigSqueep.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.brilliant2.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    }
                                    if(SceneManager.GetActiveScene().name == "Level 2")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.luminous3.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.spectacular4.Play();
                                        
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    
                                    
                                    }

                                    if(SceneManager.GetActiveScene().name == "Level 3")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.cosmic3.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.spectacular4.Play();
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    
                                    }
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
                    if (currentDot != null) 
                {
                    //checks for h matches
                    if (i > 0 && i < board.width - 1)
                    {
                       
                        GameObject rightDot = board.allDots[i + 1, j];
                        GameObject leftDot = board.allDots[i - 1, j];

                        if (rightDot != null && leftDot != null)
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
                                    if(currentDot.tag == "Special Helium"){
                                        scoreManager.IncreaseScore(75);
                                    }else{
                                        scoreManager.IncreaseScore(45);
                                    }
                                    wasLargeHMatch = true;
                                    if(SceneManager.GetActiveScene().name == "Level 1")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.bigSqueep.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.brilliant2.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    }
                                    if(SceneManager.GetActiveScene().name == "Level 2")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.luminous3.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.spectacular4.Play();
                                        
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    
                                    
                                    }

                                    if(SceneManager.GetActiveScene().name == "Level 3")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.cosmic3.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.spectacular4.Play();
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    
                                    }
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
                    if (currentDot != null)
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
                                    if(currentDot.tag == "Special Helium"){
                                        scoreManager.IncreaseScore(45);
                                    }else{
                                        scoreManager.IncreaseScore(15);
                                    }
                                    if(SceneManager.GetActiveScene().name == "Level 1")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.bigSqueep.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.brilliant2.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    }
                                    if(SceneManager.GetActiveScene().name == "Level 2")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.luminous3.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.spectacular4.Play();
                                        
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    
                                    
                                    }

                                    if(SceneManager.GetActiveScene().name == "Level 3")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.cosmic3.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.spectacular4.Play();
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    
                                    }
                                    
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
                if(currentDot.tag == "Dust Clump")
                {

                }else{
                if (currentDot != null)
                {
                    if (j > 0 && j < board.height - 1)
                    {
                        
                        GameObject upDot = board.allDots[i, j + 1];
                        GameObject downDot = board.allDots[i, j - 1];
                            
                        if (upDot != null && downDot != null )
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
                                    if(currentDot.tag == "Special Helium"){
                                        scoreManager.IncreaseScore(200);
                                    }else{
                                        scoreManager.IncreaseScore(50);
                                    }
                                    wasLargeVMatch = true;
                                    if(SceneManager.GetActiveScene().name == "Level 1")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.bigSqueep.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.brilliant2.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    }
                                    if(SceneManager.GetActiveScene().name == "Level 2")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.luminous3.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.spectacular4.Play();
                                        
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    
                                    
                                    }

                                    if(SceneManager.GetActiveScene().name == "Level 3")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.cosmic3.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.spectacular4.Play();
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    
                                    }

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
                if(currentDot.tag == "Dust Clump")
                {

                }else{
                if (currentDot != null)
                {
                    if (j > 0 && j < board.height - 1)
                    {
                        
                        GameObject upDot = board.allDots[i, j + 1];
                        GameObject downDot = board.allDots[i, j - 1];
                            
                        if (upDot != null && downDot != null)
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
                                    if(currentDot.tag == "Special Helium"){
                                        scoreManager.IncreaseScore(75);
                                    }else{
                                        scoreManager.IncreaseScore(25);
                                    }
                                    wasLargeVMatch = true;
                                    if(SceneManager.GetActiveScene().name == "Level 1")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.bigSqueep.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.brilliant2.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    }
                                    if(SceneManager.GetActiveScene().name == "Level 2")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.luminous3.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.spectacular4.Play();
                                        
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    
                                    
                                    }

                                    if(SceneManager.GetActiveScene().name == "Level 3")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.cosmic3.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.spectacular4.Play();
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    
                                    }

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
                if(currentDot.tag == "Dust Clump")
                {

                }else{
                if (currentDot != null)
                {
                    if (j > 0 && j < board.height - 1)
                    {
                        
                        GameObject upDot = board.allDots[i, j + 1];
                        GameObject downDot = board.allDots[i, j - 1];
                            
                        if (upDot != null && downDot != null)
                        {
                                
                            
                                if (upDot.tag == currentDot.tag && downDot.tag == currentDot.tag)
                                {
                                    upDot.GetComponent<Dot>().isMatched = true;
                                    
                                    downDot.GetComponent<Dot>().isMatched = true;
                                    currentDot.GetComponent<Dot>().isMatched = true;
                                    alreadyMatched = true;
                                    Debug.Log("we got a 3 match vert");
                                    if(currentDot.tag == "Special Helium"){
                                        scoreManager.IncreaseScore(45);
                                    }else{
                                        scoreManager.IncreaseScore(15);
                                    }
                                    
                                    wasLargeVMatch = true;
                                    if(SceneManager.GetActiveScene().name == "Level 1")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.bigSqueep.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.brilliant2.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    }
                                    if(SceneManager.GetActiveScene().name == "Level 2")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.luminous3.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.spectacular4.Play();
                                        
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    
                                    
                                    }

                                    if(SceneManager.GetActiveScene().name == "Level 3")
                                    {
                                        int soundNum = Random.Range(0, 8);
                                        if(soundNum == 0){
                                            AM.bloop1.Play();
                                        }
                                    else if(soundNum == 1){
                                        AM.radiant1.Play();
                                    }
                                    else if(soundNum == 2){
                                        AM.bloop4.Play();
                                    }
                                    else if(soundNum == 3){
                                        AM.cosmic3.Play();
                                    }
                                    else if(soundNum == 4){
                                        AM.squeep.Play();
                                    }
                                    else if(soundNum == 5){
                                        AM.stellar1.Play();
                                    }
                                    else if(soundNum == 6){
                                        AM.spectacular4.Play();
                                    }
                                    else if(soundNum == 7){
                                        AM.matchSound.Play();
                                    }
                                    
                                    }

                                            }

                                            }
                                            }
                                            }
                                            }
            }
                                            }
    }
                            }

                            
                                    
                                

