using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int year;
    public GameObject pauseScreen;
    public int yearInSec = 20;
    public TextMeshProUGUI yearWord;
    float sTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(false);
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
    }

    public bool newYear()
    {
        if (sTime >= yearInSec)
        {
            sTime = 0;
            year++;
            yearWord.text = year.ToString();    
            return true;
        }
        return false;
    }
}
