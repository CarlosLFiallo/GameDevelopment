using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashMeter : MonoBehaviour
{
    public PlayerControls player;
    public Slider slider;
    public Image fill;
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<PlayerControls>();
        slider.maxValue = player.dashRate;        
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = player.dashRate;
        slider.value = player.timeBetweenDash;
        if (player.timeBetweenDash < 0 ) 
        {
            slider.value = slider.maxValue;           
        }
        if(player.timeBetweenDash < slider.maxValue) 
        {
            fill.color = Color.gray;
        } 
        else if(player.timeBetweenDash >= slider.maxValue) 
        {
            fill.color = Color.white;
        }
    }
}
