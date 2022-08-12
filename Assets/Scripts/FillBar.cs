using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FillBar : MonoBehaviour
{

    public Image fillBar;

    private float lev1max = 2000;
    private float lev2max = 3000;
    private float lev3max = 4000;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeFillBar(float score)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level 1")
        {
            if(score> lev1max)
            {
                score = lev1max;
                fillBar.fillAmount = score;
            }
            else
            {
                Debug.Log("changing fill score");

                score = score / lev1max;
                fillBar.fillAmount = score;
            }
        }
        if (scene.name == "Level 2")
        {
            if (score > lev2max)
            {
                score = lev2max;
                fillBar.fillAmount = score;
            }
            else
            {
                score = score / lev2max;
                fillBar.fillAmount = score;
            }
        }
        if (scene.name == "Level 3")
        {
            if (score > lev3max)
            {
                score = lev3max;
                fillBar.fillAmount = score;
            }
            else
            {
                score = score / lev3max;
                fillBar.fillAmount = score;
            }
        }
    }
}
