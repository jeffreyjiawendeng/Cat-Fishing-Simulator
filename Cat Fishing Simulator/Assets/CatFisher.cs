using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CatFisher : MonoBehaviour
{
    public static int totalFishCatched = 0;
    public static int population = 0;
    //public GameController g;
    private int timeToFish;
    private int age;
    private int lifeExpectancy;
    void Start()
    {
        //g = FindObjectOfType<GameController>().GameController;
        population++;
        timeToFish = Random.Range(10, 15);
        age = 0;
        lifeExpectancy = Random.Range(8, 10);
        for (int i = 0; i < population; i++)
        {

        }
    }

    void Update()
    {
        if (Time.time > 5 * Random.Range(1, 2))
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
