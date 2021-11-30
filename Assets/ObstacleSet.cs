using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSet : MonoBehaviour
{

    public float xSpeed;
    public GameObject floorPlateAttach;
    public List<GameObject> floorPlates;

    // Start is called before the first frame update
    void Start()
    {
        GameObject floorPlate = GameObject.Instantiate(PickRandomFloorPlate());
        floorPlate.transform.parent = transform;
        floorPlate.transform.position = floorPlateAttach.transform.position;

    }

    GameObject PickRandomFloorPlate()
    {
        int index = Random.Range(0, floorPlates.Count);
        return floorPlates[index];
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
