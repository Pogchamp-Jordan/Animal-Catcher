using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float zSpawn;
    public float xRange;
    public float minTimeToSpawn;
    public float maxTimeToSpawn;
    public float decreaseTimeRate;
    public float minTime;
    private float spawnTime = 0;

    void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime < 0)
        {
            Spawn();
            spawnTime = Random.Range(minTimeToSpawn, maxTimeToSpawn);
        }

        minTimeToSpawn -= decreaseTimeRate * Time.deltaTime;
        maxTimeToSpawn -= decreaseTimeRate * Time.deltaTime;

        if (minTimeToSpawn < minTime) minTimeToSpawn = minTime;
        if (maxTimeToSpawn < minTime) maxTimeToSpawn = minTime;
    }

    void Spawn()
    {
        GameObject animalPrefab = animalPrefabs[Random.Range(0, animalPrefabs.Length - 1)];

        Instantiate(animalPrefab, new Vector3(Random.Range(-xRange, xRange), animalPrefab.transform.position.y, zSpawn), animalPrefab.transform.rotation);
    }

}
