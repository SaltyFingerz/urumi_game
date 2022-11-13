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
      
       
        if(EnemyHealth <= 0)
        {
            StartCoroutine(EnemyDie());
            
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

    IEnumerator EnemyDie()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Death");
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);

    }

    public void HitPlayer()
    {
        if (PlayerMovement.inRange)
        {
            PlayerMovement.PlayerHealth -= 1;
        }
    }
}
