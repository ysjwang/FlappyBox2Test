using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSet : MonoBehaviour
{

    public float xSpeed;
    public GameObject floorPlateAttach;
    public GameObject ceilingPlateAttach;
    public List<GameObject> floorPlates;
    public List<GameObject> ceilingPlates;

    public GameObject internalObstaclePrefab;

    public int minNumObstacles;
    public int maxNumObstacles;
    public float minObstacleSizeX;
    public float maxObstacleSizeX;
    public float minObstacleSizeY;
    public float maxObstacleSizeY;

    public float internalSpawnMinX;
    public float internalSpawnMaxX;
    public float internalSpawnMinY;
    public float internalSpawnMaxY;

    // Start is called before the first frame update
    void Start()
    {
        GameObject floorPlate = GameObject.Instantiate(RandomFloorPlate());
        floorPlate.transform.parent = transform;
        floorPlate.transform.position = floorPlateAttach.transform.position;

        GameObject ceilingPlate = GameObject.Instantiate(RandomCeilingPlate());
        ceilingPlate.transform.parent = transform;
        ceilingPlate.transform.position = ceilingPlateAttach.transform.position;

        SpawnInternalObstacles();

    }


    void SpawnInternalObstacles()
    {
        int numObstacles = Random.Range(minNumObstacles, maxNumObstacles + 1);
        for(int i = 0; i < numObstacles; i++)
        {
            float spawnX = Random.Range(internalSpawnMinX, internalSpawnMaxX);
            float spawnY = Random.Range(internalSpawnMinY, internalSpawnMaxY);

            float obstacleSizeX = Random.Range(minObstacleSizeX, maxObstacleSizeX);
            float obstacleSizeY = Random.Range(minObstacleSizeY, maxObstacleSizeY);

            GameObject internalObstacle = GameObject.Instantiate(internalObstaclePrefab);
            internalObstacle.transform.parent = gameObject.transform;
            internalObstacle.transform.localPosition = new Vector3(spawnX, spawnY, 0.0f);
            internalObstacle.transform.localScale = new Vector3(obstacleSizeX, obstacleSizeY, 5.0f);

        }
    }


    GameObject RandomFloorPlate()
    {
        int index = Random.Range(0, floorPlates.Count);
        return floorPlates[index];
    }

    GameObject RandomCeilingPlate()
    {
        int index = Random.Range(0, ceilingPlates.Count);
        return ceilingPlates[index];
    }

    // Update is called once per frame
    void Update()
    {
        DoMove();
    }

    void DoMove()
    {
        transform.Translate(xSpeed, 0.0f, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ObstacleCleanup"))
        {
            Debug.Log("Obstacle getting cleaned up!");
            Destroy(gameObject);
        }
    }
}
