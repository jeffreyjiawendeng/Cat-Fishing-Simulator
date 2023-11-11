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
    private int birthYear;
    private int deathYear;
    void Start()
    {
        population++;
        g = FindObjectOfType<GameController>().GetComponent<GameController>();
        timeToFish = Random.Range(10, 15);
        birthYear = GameController.year;
        deathYear = birthYear + Random.Range(8, 10);
    }

    void Update()
    {
        if (g.year > deathYear)
        {
            Destroy(this.gameObject);
        }
    }

    void catchFish()
    {
        totalFishCatched++;
    }

    void changePopulation(int fish)
    {

    }

    private void OnBecameInvisible()
    {
        
    }
}
