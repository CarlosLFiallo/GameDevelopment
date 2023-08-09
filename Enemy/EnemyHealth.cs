using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    public float randomDrop;
    public GameObject basicDrop;
    public GameObject rareDrop;
    public GameObject legendaryDrop;
    [SerializeField] private float currentHealth;

    void Start()
    {
        currentHealth = enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0) 
        {
            Destroy(gameObject);
            randomDrop = Random.Range(0,10);
        }

        if (currentHealth == 0 && randomDrop < 5)
        {
            return;
        }
        else if (currentHealth == 0 && randomDrop > 5)
        {
            Instantiate(basicDrop, transform.position, Quaternion.identity);
        }
        else if (currentHealth == 0 && randomDrop == 9 || currentHealth == 0 && randomDrop == 8)
        {
            Instantiate(rareDrop, transform.position, Quaternion.identity);
        }
        else if (currentHealth == 0 && randomDrop == 10) 
        {
            Instantiate(legendaryDrop, transform.position, Quaternion.identity);
        }
           
    }

     public void TakeDamage(float damageAmount)
     {
        currentHealth -= damageAmount;
        // Add any necessary logic here based on the damage taken
     }
}
