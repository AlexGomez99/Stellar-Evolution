using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level1CutSceneManager : MonoBehaviour
{
    public GameObject text;
    public GameObject text1;
    public GameObject text2;
    public GameObject textbox1;
    public GameObject textbox2;
    public GameObject supernova;
    public GameObject pressToStartTtx;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;
    public GameObject background;
    public GameObject hyperspace;
    public GameObject continueTtx;
    public GameObject text7;
    public GameObject text2b;

    public int counter = 0;

    public void changeclip()
    {
        if (counter == 0)
        {
            pressToStartTtx.SetActive(false);
            text.SetActive(true);
            supernova.SetActive(true);
            background.SetActive(true);
            textbox1.SetActive(false);
            textbox2.SetActive(true);
            

        }
        if (counter == 1)
        {
            text.SetActive(false);

            text1.SetActive(true);
            textbox1.SetActive(true);
            textbox2.SetActive(false);


        }
        if (counter == 2)
        {
            text1.SetActive(false);
            text2.SetActive(true);
            textbox2.SetActive(true);
            textbox1.SetActive(false);
        }    
        if (counter == 3)
        {
            text2.SetActive(false);
            text2b.SetActive(true);
            textbox2.SetActive(true);
            textbox1.SetActive(false);

        }
        if (counter == 4)
        {
            text2b.SetActive(false);
            textbox2.SetActive(false);
            textbox1.SetActive(true);
            text3.SetActive(true);

        }   

        
        if (counter == 5)
        {
            textbox2.SetActive(true);
            text3.SetActive(false);
            text4.SetActive(true);
            textbox1.SetActive(false);
        }   
        if (counter == 6)
        {
            textbox2.SetActive(false);
            text4.SetActive(false);
            textbox1.SetActive(true);
            text5.SetActive(true);
        }   
        if (counter == 7)
        {
            textbox1.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(true);
            textbox2.SetActive(true);
        }   
        if (counter == 8)
        {
            hyperspace.SetActive(true);
            background.SetActive(false);
            text6.SetActive(false);
            textbox2.SetActive(false);
            supernova.SetActive(false);
            textbox1.SetActive(true);
            continueTtx.SetActive(true);
        } 
        if (counter == 9)
        {
            SceneManager.LoadScene("Level 1");
        } 


        counter++;
    }
}
