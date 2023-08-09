using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class PointsAndUpgrade : MonoBehaviour
{
    public PlayerControls player;
    public GameObject upgradeMenu;
    public bool isScreenActive;
    public float currentPoints;
    public float pointsUntilUpgrade;
    public float pointValue;
    public float upgradeSpeed;
    public float upgradeDash;
    public float upgradeFireRate;
    void Start()
    {        
        currentPoints = 0;
        Debug.Log(isScreenActive);
        upgradeMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPoints >= 50) 
        {
            if(currentPoints >= pointsUntilUpgrade) 
            {
                upgradeMenu.SetActive(true);
                Time.timeScale = 0;
                IncreaseUpgradeCap();
            }
        }
    }

    public void IncreasePoints() 
    {
        currentPoints += pointValue;
    }

    public void IncreaseUpgradeCap() 
    {
        pointsUntilUpgrade = currentPoints * 1.5f;
    }

    public void IncreaseSpeed()
    {
        player.speed += upgradeSpeed;

    }
    public void IncreaseDash()
    {
        player.dashRate -= upgradeDash;
    }
    public void IncreaseFireRate()
    {
        player.fireRate -= upgradeFireRate;
    }
    public void ResumeGame()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1;
    }


}
