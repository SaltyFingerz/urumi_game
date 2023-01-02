using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarManager : MonoBehaviour
{
    //this script controls the health bar, making it respond to the healthpoints of the player. It was written following this tutorial: www.youtube.com/watch?v=NE5cAlCRgzo
    private Image HealthBar;
   
    private float MaxHealth = 50f;
  

    private void Start()
    {
        HealthBar = GetComponent<Image>();
    
    }


    private void Update()
    {
        HealthBar.fillAmount = PlayerMovement.PlayerHealth / MaxHealth;
    }
}
