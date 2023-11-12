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
        g = FindObjectOfType<GameController>().GetComponent<GameController>();
        population++;
        timeToFish = Random.Range(3, 6);
        birthYear = g.year;
<<<<<<< Updated upstream
        deathYear = birthYear + Random.Range(8, 11);
=======
        deathYear = birthYear + (int)Random.Range(8, 11);
        tries = 0;
        InvokeRepeating("catchFish", 0.0f, 1.0f);
>>>>>>> Stashed changes
    }

    void Update()
    {
        if (g.year == deathYear)
        {
            Destroy(this.gameObject);
        }
<<<<<<< Updated upstream
        if (Mathf.Ceil(g.sTime) % timeToFish == 0)
        {
            catchFish();
        }
=======
>>>>>>> Stashed changes
    }

    public void catchFish()
    {
<<<<<<< Updated upstream
        totalFishCatched++;
=======
        tries++;
        if ((int)timeToFish == tries) {
            totalFishCatched++;
            tries = 0;
        }
>>>>>>> Stashed changes
    }
}
