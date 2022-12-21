using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private int EnemyHealth = 5;
    public Transform target;


    [Header("Damage Overlay")]
    public Image overlay;
    public float duration;
    public float fadeSpeed;

    private float durationTimer;
    public AudioClip AttackSound;
    protected NavMeshAgent enemyMesh;
    // Start is called before the first frame update
    void Start()
    {
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
        enemyMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
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

    public void ChasePlayer()
    {
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
        }
    }
}
