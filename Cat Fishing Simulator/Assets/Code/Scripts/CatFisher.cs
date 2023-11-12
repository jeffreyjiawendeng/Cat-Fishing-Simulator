using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CatFisher : MonoBehaviour
{
    public static int totalFishCatched = 0;
    public static int population = 0;
    public GameController g;
    private float timeToFish;
    private int birthYear;
    private int deathYear;
    void Start()
    {
        population++;
        g = FindObjectOfType<GameController>().GetComponent<GameController>();
        timeToFish = Random.Range(3, 6);
        birthYear = g.year;
        deathYear = birthYear + (int)Random.Range(8, 11);
    }

    void Update()
    {
        if (g.year == deathYear)
        {
            Destroy(this.gameObject);
        }
        if (g.sTime == timeToFish || g.sTime == timeToFish * 2 || g.sTime == timeToFish * 3 || g.sTime == timeToFish)
        {
            catchFish();
        }
    }

    public void catchFish()
    {
        g.fishCaught();
        totalFishCatched++;
    }
}
