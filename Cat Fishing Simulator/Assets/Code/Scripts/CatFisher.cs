using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CatFisher : MonoBehaviour
{
    public static int totalFishCatched = 0;
    public static int population = 0;
    public GameController g;
    private int timeToFish;
    private int tries;
    private int birthYear;
    private int deathYear;
    void Start()
    {
        population++;
        g = FindObjectOfType<GameController>().GetComponent<GameController>();
        timeToFish = Random.Range(1, 6);
        birthYear = g.year;
        deathYear = birthYear + (int)Random.Range(8, 11);
        tries = 0;
        InvokeRepeating("catchFish", 0.0f, 1.0f);
    }

    void FixedUpdate()
    {
        if (g.year == deathYear)
        {
            Destroy(this.gameObject);
        }
    }

    public void catchFish()
    {
        tries++;
        if (tries == timeToFish)
        {
            g.fishCaught();
            totalFishCatched++;
            tries = 0;
        }
        
    }
}
