using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTiming : MonoBehaviour
{
    
    public static bool damageNow = false;


 
    
    public GameObject HitParticle;
    public void DamageStab()
    {
        
            DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
            DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
            // StartCoroutine(EnemyHurtRight());
            HitParticle.SetActive(true);

            Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.3f,
                       transform.position.y + 0.4f, DirectionDetection.EnemyID.gameObject.transform.position.z + 0.5f), Quaternion.Euler(0, -45, 0));
        HitParticle.GetComponent<ParticleSystem>().Play();


        
    }

    public void DamageRight()
    {
     
            DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
            DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
            // StartCoroutine(EnemyHurtRight());
            HitParticle.SetActive(true);

            Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x - 0.6f,
                        transform.position.y + 0.2f, DirectionDetection.EnemyID.gameObject.transform.position.z + 0.6f), DirectionDetection.EnemyID.gameObject.transform.rotation);
        

    }

    public void DamageLeft()
    {
       
            DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
            DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
            // StartCoroutine(EnemyHurtRight());
            HitParticle.SetActive(true);
            Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.9f,
                                      transform.position.y + 0.2f, DirectionDetection.EnemyID.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));
        

    }

    public void DamageUp()
    {
       
            DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
            DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
            // StartCoroutine(EnemyHurtRight());
            HitParticle.SetActive(true);
            Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.9f,
                                      transform.position.y + 0.2f, DirectionDetection.EnemyID.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));
        

    }

    public void DamageDown()
    {
       
            DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
            DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
            // StartCoroutine(EnemyHurtRight());
            HitParticle.SetActive(true);
            Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.9f,
                                      transform.position.y + 0.2f, DirectionDetection.EnemyID.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));
        

    }


    public void DamageTopLeft()
    {

        DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
        DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
        // StartCoroutine(EnemyHurtRight());
        HitParticle.SetActive(true);
        Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.9f,
                                  transform.position.y + 0.2f, DirectionDetection.EnemyID.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));


    }

    public void DamageBottomLeft()
    {

        DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
        DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
        // StartCoroutine(EnemyHurtRight());
        HitParticle.SetActive(true);
        Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.9f,
                                  transform.position.y + 0.2f, DirectionDetection.EnemyID.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));


    }

    public void DamageBottomRight()
    {

        DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
        DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
        // StartCoroutine(EnemyHurtRight());
        HitParticle.SetActive(true);
        Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.9f,
                                  transform.position.y + 0.2f, DirectionDetection.EnemyID.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));


    }

    public void DamageTopRight()
    {

        DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
        DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
        // StartCoroutine(EnemyHurtRight());
        HitParticle.SetActive(true);
        Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.9f,
                                  transform.position.y + 0.2f, DirectionDetection.EnemyID.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));


    }




}
