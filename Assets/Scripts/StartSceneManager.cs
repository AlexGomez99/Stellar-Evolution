using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartSceneManager : MonoBehaviour
{
    private AudioManager AM;
    // Start is called before the first frame update
    void Start()
    {
        AM = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Opening Scene");
        AM.ascendingSaucer.Play();
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Start Scene");
    }
    public void Quit(){
        Application.Quit();
    }
}
