using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTiming : MonoBehaviour
{
    
    public static bool damageNow = false;


 
    
    public GameObject HitParticle;
    public void DamageStab()
    {
        if (DirectionDetection.EnemyID != null)
        {
            if (DirectionDetection.EnemyID.GetComponent<Animator>() != null)
                DirectionDetection.EnemyID.GetComponent<Animator>().SetTrigger("Damage");
            if (DirectionDetection.EnemyID.GetComponent<EnemyController>() != null)
                DirectionDetection.EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
            // StartCoroutine(EnemyHurtRight());
            HitParticle.SetActive(true);

            Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.3f,
                       transform.position.y + 0.4f, DirectionDetection.EnemyID.gameObject.transform.position.z + 0.5f), Quaternion.Euler(0, -45, 0));
            HitParticle.GetComponent<ParticleSystem>().Play();
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
            // StartCoroutine(EnemyHurtRight());
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
            // StartCoroutine(EnemyHurtRight());
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
            // StartCoroutine(EnemyHurtRight());
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
            // StartCoroutine(EnemyHurtRight());
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
            // StartCoroutine(EnemyHurtRight());
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
            // StartCoroutine(EnemyHurtRight());
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
            // StartCoroutine(EnemyHurtRight());
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
            // StartCoroutine(EnemyHurtRight());
            HitParticle.SetActive(true);
            Instantiate(HitParticle, new Vector3(DirectionDetection.EnemyID.gameObject.transform.position.x + 0.9f,
                                      transform.position.y + 0.2f, DirectionDetection.EnemyID.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));
        }

    }




}
