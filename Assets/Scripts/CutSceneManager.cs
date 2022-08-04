using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    public GameObject text;
    public GameObject text1;
    public GameObject text2;

    public int counter = 0;

    public void changeclip()
    {
        if (counter == 0)
        {
            text.SetActive(true);

        }
        if (counter == 1)
        {
            text.SetActive(false);

            text1.SetActive(true);

        }
        if (counter == 2)
        {
            text1.SetActive(false);
            text2.SetActive(true);

        }
        counter++;
    }
}
