using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFisher : MonoBehaviour
{
    static int fishCatched;
    static int population;

    void Start()
    {
        population = 100;
        for (int i = 0; i < population; i++)
        {

        }
    }

    void Update()
    {
        
    }

    void catchFish()
    {
        fishCatched++;
    }

    private void OnBecameInvisible()
    {
        
    }
}
