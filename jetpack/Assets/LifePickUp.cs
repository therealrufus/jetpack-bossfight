using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickUp : MonoBehaviour
{
    public float spawnRate = 50f;
    public GameObject presik;
    public float startSpawning = 100f;

    void Start()
    {
        InvokeRepeating("SpawnLife", startSpawning, spawnRate);
    }

    void SpawnLife()
    {
        Debug.Log("Život spawned");
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-8, 9), Random.Range(-4, 3));
        Instantiate(presik, randomSpawnPosition, Quaternion.identity);
    }
}
