using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject tutorialScreen;

    // Start is called before the first frame update
    void Start()
    {
        tutorialScreen.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        closeTut();
    }

    public void play()
    {
        SceneManager.LoadScene(1);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void quid()
    {
        Application.Quit(); 
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void openTut()
    {
        tutorialScreen.SetActive(true);
    }

    public void closeTut()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            tutorialScreen.SetActive(false);
        }
    }
}
