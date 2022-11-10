using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int EnemyHealth = 5;
    public Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        print(EnemyHealth);
        if(EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }

        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        if(target != null)
        {
            
            transform.LookAt(targetPosition);
           // transform.position = Vector3.Lerp(transform.position, target.position, 0.01f);
        }

    }

    public void ReduceHealth(int damage)
    {
        EnemyHealth -= damage;
    }

    public int GetHealth()
    {
        return EnemyHealth;
    }
}
