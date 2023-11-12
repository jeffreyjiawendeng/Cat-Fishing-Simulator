/*
 * Script that instantiates cats a random distance & direction from the pond as long as they are between the two assigned distances
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameController controller;
    [SerializeField]
    private GameObject cat;

    public void SpawnCat(float minDistance, float maxDistance)
    {
        Vector3 location = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up) * Vector3.forward * Random.Range(minDistance, maxDistance);
        RaycastHit hit;

        // Attempting to place the cat directly on top of the terrain so that the nav mesh agent is on the nav mesh surface
        if (Physics.Raycast(location + Vector3.down * 1000, transform.up, out hit) || Physics.Raycast(location + Vector3.up * 1000, -transform.up, out hit))
        {
            if (hit.collider.gameObject.tag.Equals("Ground"))
            {
                var newCat = Instantiate(cat, hit.point, cat.transform.rotation);
                newCat.GetComponent<CatFisher>().g = controller; // Cats instantiated from prefab have g as null by default
                controller.cats.Add(newCat.GetComponent<CatFisher>());
            }
            else if (minDistance > 0 && maxDistance > 0)    // Recursively spawning a cat if the raycast missed
                SpawnCat(minDistance - 5, maxDistance - 5);
        }
    }
}
