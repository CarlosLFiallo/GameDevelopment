using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationForDrops : MonoBehaviour
{

    // Update is called once per frame
    public Vector3 rotationSpeed = new Vector3(0f, 10f, 0f); // Adjust the rotation speed in each axis

    void Update()
    {
        // Apply a gradual rotation over time
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
