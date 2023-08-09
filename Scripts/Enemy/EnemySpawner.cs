using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public GameObject basicEnemy;
    public GameObject rareEnemy;
    public GameObject epicEnemy;
    public WorldClock clock;
    public int minimumRange = 0;
    public int maximumRange = 10;
    public float timerDuration = 5f;
    public float timerDeduction;
    public float howLongUntilNextSpawn;

    private float timer;
    private int whoWillSpawn;
    void Start()
    {
        timer = timerDuration;
        Instantiate(basicEnemy, new Vector3(0,1,0), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        FindEnemy();    
        TimerCountdown();
    }

    void EnemySpawn() 
    {
        var position = new Vector3(Random.Range(-16, 16), 1, Random.Range(-5f, 2f));

        if (whoWillSpawn < 3 )
        {
            Instantiate(rareEnemy, position, transform.rotation);
            

        }
        else if(whoWillSpawn == 3) 
        {
            Instantiate(epicEnemy, position, transform.rotation);

        }
        else Instantiate(basicEnemy, position, transform.rotation);
        
    }

    void TimerCountdown()
    {
        clock = GetComponent<WorldClock>();
        if (timer > 0)
        {
            // Update the timer by subtracting the elapsed time
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = timerDuration;
                whoWillSpawn = Random.Range(minimumRange, maximumRange);
                EnemySpawn();                
            }
        }

        if (clock.clock >= howLongUntilNextSpawn)
        {
            timerDuration -= timerDeduction;
            clock.clock = 0;
        }
    }
    void FindEnemy()
    {
        var enemies = GameObject.FindGameObjectsWithTag("enemy");
        int enemiesNumber = enemies.Length;

        if (enemiesNumber > 20 )
        {
            Destroy(enemies[0]);

        }
        
    }
}   

