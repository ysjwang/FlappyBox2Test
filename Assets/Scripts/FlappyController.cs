using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyController : MonoBehaviour
{
    public float upForce;
    
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Pressed Space
            rigidBody.AddForce(new Vector3(0, upForce, 0));
            Debug.Log("Pressed Space");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("collided with obstacle");
        }
    }
}
