using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyShoot : MonoBehaviour
   
{
    public AudioSource shootSound;
    public GameObject basicProjectile;
    public float timerDuration = 5f;

    private float timer;
    void Start()
    {
        timer = timerDuration;
       
    }

    // Update is called once per frame
    void Update()
    {
        TimerCountdown();
    }
    void TimerCountdown()
    {
        if (timer > 0)
        {
            // Update the timer by subtracting the elapsed time
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = timerDuration;
                Instantiate(basicProjectile, transform.position + new Vector3(0, 0, -2), new Quaternion(0, 1, 1, 0));
                shootSound.Play();
            }
        }
    }
}
