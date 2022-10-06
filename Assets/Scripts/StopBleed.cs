using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBleed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StopBleeding());
    }

 

    IEnumerator StopBleeding()
    {
        yield return new WaitForSeconds(1.0f);
      
        
        gameObject.SetActive(false);
    }
}
