using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnTrigger : MonoBehaviour
{

    public GameObject spawnObject;
    public GameObject spawnPointObject;
    Vector3 spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = spawnPointObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacleSet()
    {
        Debug.Log("Spawnning");
        GameObject newObstacleSet = GameObject.Instantiate(spawnObject);
        newObstacleSet.transform.position = spawnLocation;
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tag is " + other.tag);
        if (other.CompareTag("SpawnTriggerHead"))
        {
            Debug.Log("Spawning a new instance...");
            SpawnObstacleSet();
        }
    }
}
