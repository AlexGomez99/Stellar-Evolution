using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StarCard : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool GameIsPaused = false;

    public GameObject starCard;
    // Update is called once per frame
    void Update()
    {



    }

    public void Resume()
    {
        if (SceneManager.GetActiveScene().name == "Level 2")
            {
                SceneManager.LoadScene(sceneName: "level 3");
            }
        
        else if (SceneManager.GetActiveScene().name == "Level 1")
            {
                SceneManager.LoadScene(sceneName: "level 2");
            }
    }

   public void Pause()
    {
        starCard.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

}