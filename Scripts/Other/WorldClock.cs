using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldClock : MonoBehaviour
{
    public float clock;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
    }
}
