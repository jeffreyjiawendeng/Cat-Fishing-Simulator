using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int year;
    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    public int yearInSec = 20;

    public float sTime = 0;
    public float fishMultiplier = 1.4f;


    public int fishCount = 50;
    public int catCount = 5;

    public TextMeshProUGUI yearWord;
    public TextMeshProUGUI fishWord;
    public TextMeshProUGUI catWord;

    // Start is called before the first frame update
    void Start()
    {
        fishWord.text = fishCount.ToString();
        catWord.text = catCount.ToString();

        pauseScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        yearWord.text = year.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        sTime += Time.deltaTime;
        newYear();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeSelf)
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (fishCount <= 0 || catCount <= 0)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;

        }
    }

    public void fishCaught()
    {
        fishCount--;
    }


    public void newYear()
    {
        if (sTime >= yearInSec)
        {
            sTime = 0;
            year++;
            yearWord.text = year.ToString();    

        }

        catCount = FindObjectsOfType<CatFisher>().Length;
        fishWord.text = fishCount.ToString();
        catWord.text = catCount.ToString();

    }

    private void fishbreeding()
    {
        fishCount += (int) (fishCount * fishMultiplier);
    }
        
}
