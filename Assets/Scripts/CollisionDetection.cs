using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private DirectionDetection wc;
    public GameObject HitParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" )
        {
            print("HIT");
            other.GetComponent<Animator>().SetTrigger("Hit");
            HitParticle.SetActive(true);
            if (wc.fromRight)
            {
                print("BLEED");
                Instantiate(HitParticle, new Vector3(other.transform.position.x - 0.6f,
                    transform.position.y + 0.2f, other.transform.position.z + 0.6f), other.transform.rotation);
                
                
            }
            else if (wc.fromLeft)
            {
                print("BLEED");
                Instantiate(HitParticle, new Vector3(other.transform.position.x + 0.9f,
                    transform.position.y + 0.2f, other.transform.position.z -0.2f), Quaternion.Euler(0, 0, 0));
                


            }
           
        }
    }


   

  
}
