using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    
    public GameObject HitParticle;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && DirectionDetection.isAttacking)
        {
            print("STEP1");
            other.GetComponent<Animator>().SetTrigger("Hit");
            HitParticle.SetActive(true);
            if (DirectionDetection.fromRight)
            {
                print("hurt from right");
                Instantiate(HitParticle, new Vector3(other.transform.position.x - 0.6f,
                    transform.position.y + 0.2f, other.transform.position.z + 0.6f), other.transform.rotation);
                
                
            }
            else if (DirectionDetection.fromLeft)
            {
                print("hurt from left");
                Instantiate(HitParticle, new Vector3(other.transform.position.x + 0.9f,
                    transform.position.y + 0.2f, other.transform.position.z -0.2f), Quaternion.Euler(0, 0, 0));
                


            }

            else if (DirectionDetection.fromCentre)
            {
               
                Instantiate(HitParticle, new Vector3(other.transform.position.x + 0.3f,
                    transform.position.y + 0.4f, other.transform.position.z +0.5f), Quaternion.Euler(0, -45, 0));



            }

        }
    }


   

  
}
