using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CatFisher : MonoBehaviour
{
    public static int totalFishCatched = 0;
    public static int population = 0;
    public GameController g;
    public int timeToFish;
    private int tries;
    public int fishCaught;
    public int fishToReproduce;
    private int birthYear;
    public int deathYear;
    void Start()
    {
        population++;
        g = FindObjectOfType<GameController>().GetComponent<GameController>();
        timeToFish = Random.Range(1, 4);
        birthYear = g.year;
        deathYear = birthYear + (int)Random.Range(8, 11);
        fishToReproduce = (int)Random.Range(1, 4);
        fishCaught = 0;
        tries = 0;
        InvokeRepeating("catchFish", 0.0f, 1.0f);
    }

    void FixedUpdate()
    {
        if (g.year >= deathYear)
        {
            g.cats.Remove(this);
            g.catCount--;
            Destroy(this.gameObject);
        }
    }

    public void catchFish()
    {
        tries++;
        if (tries == timeToFish && g.fishCount > 0)
        {
            g.fishCaught();
            totalFishCatched++;
            tries = 0;
            fishCaught++;
        }
        
    }
}
