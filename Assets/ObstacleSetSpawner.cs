using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSetSpawner : MonoBehaviour
{

    public float spawnTimer;
    public GameObject spawnObject;
    public GameObject spawnPointObject;
    [SerializeField] float currentSpawnTime;
    Vector3 spawnLocation;
    

    // Start is called before the first frame update
    void Start()
    {
        currentSpawnTime = spawnTimer;
        spawnLocation = spawnPointObject.transform.position;
    }

    void Update()
    {
        RunSpawnTimer();
    }


    void RunSpawnTimer()
    {
        currentSpawnTime--;
        if (currentSpawnTime <= 0.0f)
        {
            SpawnObstacleSet();
            currentSpawnTime = spawnTimer;
        }
    }

    void SpawnObstacleSet()
    {
        Debug.Log("Spawnning");
        GameObject newObstacleSet = GameObject.Instantiate(spawnObject);
        newObstacleSet.transform.position = spawnLocation;
    }

    // Update is called once per frame
    
}
