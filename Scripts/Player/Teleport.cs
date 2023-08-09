using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Vector3 teleportPosition = new Vector3(0, 0, 0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

  
    void OnTriggerEnter(Collider collider)
    {  
        if (collider.gameObject.CompareTag("Player"))
        {
            // Teleport the player to the specified position
            collider. transform.position = teleportPosition;

            Debug.Log("Collision With Player");
        }

    }
}
