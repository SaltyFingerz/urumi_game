using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBleed : MonoBehaviour
{
    
    // this script is attached to the blood FX Extra prefab, used for the particle effect of blood when enemy is damaged.
    void Start()
    {
        StartCoroutine(StopBleeding()); //called in start function as this is when the blood effect prefab is instantiated
    }

 

    IEnumerator StopBleeding()
    {
        yield return new WaitForSeconds(1.0f); //time in which bleeding occurs
      
        
        gameObject.SetActive(false); //deactivates blood particle effect 
    }
    
}
