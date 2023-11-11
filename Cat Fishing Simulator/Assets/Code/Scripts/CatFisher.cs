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
        g = FindObjectOfType<GameController>().GetComponent<GameController>();
        population++;
        timeToFish = Random.Range(3, 6);
        birthYear = g.year;
        deathYear = birthYear + Random.Range(8, 11);
    }

    void Update()
    {
        if (g.year == deathYear)
        {
            Destroy(this.gameObject);
        }
        if (Mathf.Ceil(g.sTime) % timeToFish == 0)
        {
            catchFish();
        }
    }

    public void catchFish()
    {
        totalFishCatched++;
    }
}
