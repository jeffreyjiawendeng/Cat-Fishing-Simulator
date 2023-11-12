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
    public float fishMultiplier = 2.0f;

    public Spawner spawner;
    public int fishCount = 50;
    public int catCount = 5;

    public List<CatFisher> cats = new List<CatFisher>();

    public TextMeshProUGUI yearWord;
    public TextMeshProUGUI fishWord;
    public TextMeshProUGUI catWord;

    // Start is called before the first frame update
    void Start()
    {
        fishWord.text = fishCount.ToString();
        catWord.text = catCount.ToString();
        spawner = GetComponent<Spawner>();

        var temp = catCount;
        for (int i = 0; i < temp; i++)
        {
            spawner.SpawnCat(35, 40);
            catCount++;
        }

        pauseScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        yearWord.text = "Year : " + year.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(fishCount, 0, Mathf.Infinity);
        sTime += Time.deltaTime;
        newYear();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }

        if (catCount <= 0)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;

        }
    }

    private void pause()
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

            yearWord.text = "Year : " + year.ToString();
            fishbreeding();

            var generationCount = 0;
            foreach (CatFisher x in cats)
            {
                if (x.fishCaught >= x.fishToReproduce)
                {
                    generationCount++;
                }
                else 
                {
                    x.deathYear-=2;
                    if (fishCount <= catCount)
                        x.deathYear-=2;
                }
                x.timeToFish = Random.Range(2, 6);
                x.fishCaught = 0;
            }
            for (int i = 0; i < generationCount; i++)
            {
                spawner.SpawnCat(35, 40);
                catCount++;
            }
            fishbreeding();
        }

        catCount = FindObjectsOfType<CatFisher>().Length;
        fishWord.text = fishCount.ToString();
        catWord.text = catCount.ToString();
    }

    private void fishbreeding()
    {
        if (fishCount < 1)
            fishCount += 5;
        else 
            fishCount = (int) (fishCount * fishMultiplier);
    }

    public void addCat()
    {
        spawner.SpawnCat(35,40);
        catCount++;
    }

    public void addFish()
    {
        fishCount += 7;
    }
        
}
