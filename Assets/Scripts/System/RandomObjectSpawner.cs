using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] myObjects;
    public int numberOfObjectsToSpawn = 100;

    void Start()
    {
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            SpawnRandomObject(myObjects);
        }
    }

    void SpawnRandomObject(GameObject[] objectsToSpawn)
    {
        if (objectsToSpawn.Length == 0)
        {
            Debug.LogError("No objects to spawn. Please assign objects to the array.");
            return;
        }

        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        Vector3 randomSpawnPosition = new Vector3(Random.Range(20, 900), 107, Random.Range(20, 900));

        GameObject spawnedObject = Instantiate(objectsToSpawn[randomIndex], randomSpawnPosition, Quaternion.identity);

    }
        
}