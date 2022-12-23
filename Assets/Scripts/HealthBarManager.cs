using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarManager : MonoBehaviour
{
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
