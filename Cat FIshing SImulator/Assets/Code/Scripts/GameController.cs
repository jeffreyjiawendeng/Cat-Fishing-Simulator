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

        for (int i = 0; i < catCount; i++)
        {
            spawner.SpawnCat(35, 40);
            catCount++;
        }

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
            fishbreeding();
            foreach (CatFisher x in cats)
            {
                if (x.fishCaught >= 6)
                {
                    spawner.SpawnCat(35, 40);
                }
                else
                {
                    x.deathYear--;
                }
                x.timeToFish = Random.Range(2, 6);
                x.fishCaught = 0;
                catCount++;
            }
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
