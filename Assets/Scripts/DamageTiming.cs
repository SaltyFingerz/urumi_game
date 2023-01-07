using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class DamageTiming : MonoBehaviour
{
    //This script contains functions to be called as animation events, within the attack animations
    //The functions here check if the attack is hitting an enemy and if so triggers the enemy animation, reduces their health, instantiates a bleeding particle effect on the enemy, according to the direction of the attack.
    //This script can be used to implement different damage values according to the weapon.

    public GameObject HitParticle; //the bleeding particle effect

    public void DamageStab() //called on stab attacks
    {
        if (DirectionDetection.EnemyID != null) //checks that an enemy is being hit
        {
            if (DirectionDetection.EnemyID.GetComponent<Animator>() != null) //used to prevent error message when the eenemy  has no animator, such as the scarecrow enemy in the tutorial
                DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage"); //triggers the damage animation in the enemy's animator
            if (DirectionDetection.EnemyID.GetComponent<EnemyController>() != null) //checks that the enemy has the enemycontroller script that keeps track of the enemy health
                DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1); //reduces the enemy health by one point

            
            HitParticle.SetActive(true); //activates the blood particle effect

            Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.3f,
                       transform.position.y + 0.4f, DirectionDetection.EnemyID.gameObject.transform.position.z + 0.5f), Quaternion.Euler(0, -45, 0));  //instantiates the blood particle effect at a position and rotation adjusted to the direction of attack, so that it appears that the enemy is bleeding from the side they were hit.
            //HitParticle.GetComponent<ParticleSystem>().Play(); //plays the particle effect
        }

        
    }



    public void DamageRight()
    {
        if (DirectionDetection.EnemyID != null)
        {
            if (DirectionDetection.EnemyID.GetComponent<Animator>() != null)
            DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
            if(DirectionDetection.EnemyID.GetComponent<EnemyController>() != null)
            DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
       
            HitParticle.SetActive(true);

            Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x - 0.6f,
                        transform.position.y + 0.2f, DirectionDetection.EnemyID.gameObject.transform.position.z + 0.6f), DirectionDetection.EnemyID.gameObject.transform.rotation);
        }

    }

    public void DamageLeft()
    {
        if (DirectionDetection.EnemyID != null)
        {
            if (DirectionDetection.EnemyID.GetComponent<Animator>() != null)
                DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
            if (DirectionDetection.EnemyID.GetComponent<EnemyController>() != null)
                DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
         
            HitParticle.SetActive(true);
            Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.9f,
                                      transform.position.y + 0.2f, DirectionDetection.EnemyID.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));
        }

    }

    public void DamageUp()
    {
        if (DirectionDetection.EnemyID != null)
        {
            if (DirectionDetection.EnemyID.GetComponent<Animator>() != null)
                DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
            if (DirectionDetection.EnemyID.GetComponent<EnemyController>() != null)
                DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
        
            HitParticle.SetActive(true);
            Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.9f,
                                      transform.position.y + 0.2f, DirectionDetection.EnemyID.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));
        
            }
    }

    public void DamageDown()
    {
        if (DirectionDetection.EnemyID != null)
        {
            if (DirectionDetection.EnemyID.GetComponent<Animator>() != null)
                DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
            if (DirectionDetection.EnemyID.GetComponent<EnemyController>() != null)
                DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
          
            HitParticle.SetActive(true);
            Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.9f,
                                      transform.position.y + 0.2f, DirectionDetection.EnemyID.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));
        }

    }


    public void DamageTopLeft()
    {
        if (DirectionDetection.EnemyID != null)
        {
            if (DirectionDetection.EnemyID.GetComponent<Animator>() != null)
                DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
            if (DirectionDetection.EnemyID.GetComponent<EnemyController>() != null)
                DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
         
            HitParticle.SetActive(true);
            Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.9f,
                                      transform.position.y + 0.2f, DirectionDetection.EnemyID.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));
        }

    }

    public void DamageBottomLeft()
    {
        if (DirectionDetection.EnemyID != null)
        {
            if (DirectionDetection.EnemyID.GetComponent<Animator>() != null)
                DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
            if (DirectionDetection.EnemyID.GetComponent<EnemyController>() != null)
                DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
          
            HitParticle.SetActive(true);
            Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.9f,
                                      transform.position.y + 0.2f, DirectionDetection.EnemyID.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));

        }
    }

    public void DamageBottomRight()
    {
        if (DirectionDetection.EnemyID != null)
        {
            if (DirectionDetection.EnemyID.GetComponent<Animator>() != null)
                DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
            if (DirectionDetection.EnemyID.GetComponent<EnemyController>() != null)
                DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
           
            HitParticle.SetActive(true);
            Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.9f,
                                      transform.position.y + 0.2f, DirectionDetection.EnemyID.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));

        }
    }

    public void DamageTopRight()
    {
        if (DirectionDetection.EnemyID != null)
        {
            if (DirectionDetection.EnemyID.GetComponent<Animator>() != null)
                DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
            if (DirectionDetection.EnemyID.GetComponent<EnemyController>() != null)
                DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
           
            HitParticle.SetActive(true);
            Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.9f,
                                      transform.position.y + 0.2f, DirectionDetection.EnemyID.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));
        }

    }




}
