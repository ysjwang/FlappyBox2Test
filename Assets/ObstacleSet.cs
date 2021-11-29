using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSet : MonoBehaviour
{

    public float xSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DoMove();
    }

    void DoMove()
    {
        transform.Translate(xSpeed, 0.0f, 0.0f);
        Debug.Log("Doing move");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ObstacleCleanup"))
        {
            Debug.Log("Obstacle getting cleaned up!");
        }
    }
}
