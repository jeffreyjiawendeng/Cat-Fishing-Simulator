using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CatFisher : MonoBehaviour
{
    public static int totalFishCatched = 0;
    public static int population = 0;
    public GameController g;
    private int skillLevel;
    private int birthYear;
    private int deathYear;
    void Start()
    {
        population++;
        g = FindObjectOfType<GameController>().GetComponent<GameController>();
        skillLevel = Random.Range(2, 4);
        birthYear = g.year;
        deathYear = birthYear + (int)Random.Range(8, 11);
    }

    void Update()
    {
        if (g.year == deathYear)
        {
            Destroy(this.gameObject);
        }
        if (Random.Range(1, 1001) > 1001 - skillLevel) // YO JOSH THIS IS KIND OF A BS SOLUTION FOR NOW
        {                                              // We kinda gotta change this method
            catchFish();                               // :p
        }


    }

    public void catchFish()
    {
        g.fishCaught();
        totalFishCatched++;
    }
}
