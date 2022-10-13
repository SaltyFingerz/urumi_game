using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private weaponController wc;
    public GameObject HitParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && wc.isAttacking)
        {
            other.GetComponent<Animator>().SetTrigger("Hit");
            HitParticle.SetActive(true);
            if (wc.fromRight)
            {
                Instantiate(HitParticle, new Vector3(other.transform.position.x - 0.6f,
                    transform.position.y + 0.2f, other.transform.position.z + 0.6f), other.transform.rotation);
                
            }
            else if (wc.fromLeft)
            {
                Instantiate(HitParticle, new Vector3(other.transform.position.x + 0.9f,
                    transform.position.y + 0.2f, other.transform.position.z -0.2f), Quaternion.Euler(0, 0, 0));
                

            }
           
        }
    }


   

  
}
