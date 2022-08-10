using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCutSceneManager : MonoBehaviour
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
    public GameObject text8;
    public GameObject text9;
    public GameObject text10;
    public GameObject supernovaReveal;

    public int counter = 0;

    public void changeclip()

    {
        if (counter == 0)
        {
            pressToStartTtx.SetActive(false);
            text.SetActive(true);
            supernova.SetActive(true);
            background.SetActive(true);
        }
        if (counter == 1)
        {
            textbox1.SetActive(false);
            textbox2.SetActive(true);
            text1.SetActive(true);
            text.SetActive(false);  
        }
        if (counter == 2)
        {
            text1.SetActive(false);
            supernova.SetActive(false);
            supernovaReveal.SetActive(true);
            text2.SetActive(true);
        }
        if (counter == 3)
        {
            text2.SetActive(false);
            textbox2.SetActive(false);
            textbox1.SetActive(true);
            text3.SetActive(true);
        }
        if (counter == 4)
        {
            text3.SetActive(false);
            textbox1.SetActive(false);
            text4.SetActive(true);
            textbox2.SetActive(true);
        }
        if (counter == 5)
        {
            text4.SetActive(false);
            text5.SetActive(true);
        }
        if (counter == 6)
        {
            text5.SetActive(false);
            textbox2.SetActive(false);
            textbox1.SetActive(true);
            text6.SetActive(true);
        }
        if (counter == 7)
        {
            text6.SetActive(false);
            textbox1.SetActive(false);
            textbox2.SetActive(true);
            text7.SetActive(true);
        }
        if (counter == 8)
        {
            text7.SetActive(false);
            text8.SetActive(true);
        }
        if (counter == 9)
        {
            text8.SetActive(false);
            textbox2.SetActive(false);
            textbox1.SetActive(true);
            text9.SetActive(true);
        }
        if (counter == 10)
        {
            text9.SetActive(false);
            text10.SetActive(true);
            background.SetActive(false);
            hyperspace.SetActive(true);
        }
        if (counter == 11)
        {
            text10.SetActive(false);
            supernovaReveal.SetActive(false);
            continueTtx.SetActive(true);
        }
        if (counter == 12)
        {
            SceneManager.LoadScene("Level 3");
        }






        counter++;
    }
}
