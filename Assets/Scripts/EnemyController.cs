using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private int EnemyHealth = 3;
    public Transform target;


    [Header("Damage Overlay")]
    public Image overlay;
    private float duration = 1f;
    private float fadeSpeed = 1f;

    private float durationTimer;
    public AudioClip AttackSound;

    public GameObject Player;
   
    protected NavMeshAgent enemyMesh;
    public static bool hurtSound;

    void Start()
    {
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
        enemyMesh = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");

    }


    void Update()
    {
        

        if (overlay.color.a > 0)
        {
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }




        if (EnemyHealth <= 0)
        {
            StartCoroutine(EnemyDie());
            
        }

        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        if(target != null)
        {
            
            transform.LookAt(targetPosition);

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
        DirectionDetection.EnemyID = null;
        DirectionDetection.enemyLeftHit = false;
        DirectionDetection.enemyRightHit = false;
        DirectionDetection.enemyCenterHit = false;
        DirectionDetection.enemyUpHit = false;
        DirectionDetection.enemyDownHit = false;
        gameObject.GetComponent<Animator>().SetTrigger("Death");
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);

    }

    public void ChasePlayer()
    {
        if(gameObject.GetComponent<NavMeshAgent>().isOnNavMesh)
        enemyMesh.SetDestination(target.position);
    }
    public void HitPlayer()
    {
        if (PlayerMovement.inRange)
        {
            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(AttackSound);
            PlayerMovement.PlayerHealth -= 1;
            durationTimer = 0;
            overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0.5f);
            if (PlayerMovement.PlayerHealth >= 25)
                StartCoroutine(HurtSound());
            else if (PlayerMovement.PlayerHealth < 25)
                StartCoroutine(HurtSoundLowHP());
        }
    }

    IEnumerator HurtSound()
    {
        yield return new WaitForSeconds(0.15f);
        Player.GetComponent<PlayerMovement>().Sounds();
       

    }

    IEnumerator HurtSoundLowHP()
    {
        yield return new WaitForSeconds(0.15f);
        Player.GetComponent<PlayerMovement>().SoundsLowHP();


    }

}
