using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Newtonsoft.Json.Linq;

public class BaseHealth : MonoBehaviour
{
    public float maxBaseHealth = 100f;
    public float currentBaseHealth;
    public float numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public float healthPerHeart;  


    void Start()
    {
        currentBaseHealth = maxBaseHealth;
        healthPerHeart = maxBaseHealth / hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBaseHealth <= 0) 
        {
            Destroy(gameObject);           
        }
        HeartCounter();
    }
    public void TakeDamage(float damageAmount)
    {
        currentBaseHealth -= damageAmount;
        // Add any necessary logic here based on the damage taken
    }

    public void HeartCounter() 
    {

        for (int i = 0; i < hearts.Length; i++)
        {
            float heartHealth = currentBaseHealth - i * healthPerHeart; // Calculate the remaining health for this heart

            if (heartHealth >= healthPerHeart) // Fill the heart completely
            {
                hearts[i].sprite = fullHeart;
            }
            else if (heartHealth >= healthPerHeart / 2f) // Fill the heart halfway
            {
                hearts[i].sprite = halfHeart;
            }
            else // Empty heart
            {
                hearts[i].sprite = emptyHeart;
            }
        }

    }
}
