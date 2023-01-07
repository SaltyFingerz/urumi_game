using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{//this script is attached to every enemy (Skeletons, but not the scarecrow dummy in the tutorial.
    public GameObject Player;
    public Transform target;
    public Image overlay;
    public AudioClip AttackSound;
    protected NavMeshAgent enemyMesh;
    public static bool hurtSound;
    private int EnemyHealth = 3;
    private float duration = 1f;
    private float fadeSpeed = 1f;
    private float durationTimer;

    void Start()
    {
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0); //this sets the opacity of the damage overlay image to zero at the start; the tutorial available at: https://youtu.be/LugpgsMdLWw was used for implementing the damage overlay.
        enemyMesh = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player"); //gets the Player game object

    }


    void Update()
    {
        

        if (overlay.color.a > 0) //checks if the damage overlay image is visible
        {
            //makes the damage overlay fade away with time (from tutorial referenced above):
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }




        if (EnemyHealth <= 0) //Enemy Death
        {
            
            StartCoroutine(EnemyDie());
            
        }

        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z); //transform.position.y rather than target.transform.position.y is used to prevent the enemy from tilting off the vertical y axis. 
        if(target != null)
        {
            
            transform.LookAt(targetPosition); //makes the enemy look at the player. This line of code was learnt from the tutorial available at: www.youtube.com/watch?v=rP_bEq248e4

        }

    }

    public void ReduceHealth(int damage) //this function is called in DamageTiming.cs to reduce the health of the enemy by the damage value (set in DamageTiming.ce) each time the enemy is successfully attacked.
    {
        EnemyHealth -= damage;
    }

    public int GetHealth()
    {
        return EnemyHealth;
    }

    IEnumerator EnemyDie() //Enemy Death
    {
        DirectionDetection.EnemyID = null;    //this and the following boolean resets are so the shields of the dead enemy do not affect the player's attacks anymore
        DirectionDetection.enemyLeftHit = false;
        DirectionDetection.enemyRightHit = false;
        DirectionDetection.enemyCenterHit = false;
        DirectionDetection.enemyUpHit = false;
        DirectionDetection.enemyDownHit = false;
        //Play Enemy Dying Animation:
        gameObject.GetComponent<Animator>().SetTrigger("Death");
        //deactivate navmesh agent so that the dead skeleton ie the corpse doesnt move towards the player
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        //some time is allowed to pass where the enemy corpse can be seen before removing it from the game:
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);

    }

    public void ChasePlayer() 
    {
        if(gameObject.GetComponent<NavMeshAgent>().isOnNavMesh) //checks that the enemy is on the navmesh to prevent errors
        enemyMesh.SetDestination(target.position);  //the destination is set to the position of the target which is set to the player game object. This makes the enemy move directly towards the player.
    }
    public void HitPlayer() //this function is called as an animation event in the enemy's attack animation. The player can attack to interrupt the enemy's attack animation before the event with this function is called.
    {
        if (PlayerMovement.inRange) //while the enemy only attacks if it is in range, the player has time to escape, so whether they are still in range is checked.
        {
            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(AttackSound); //the sound of the enemy's sword swooshing 
            PlayerMovement.PlayerHealth -= 1; //the player loses one health point when attacked
            durationTimer = 0; //the damage overlay duration timer is set to zero (this was done based on the tutorial referenced above)
            overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0.5f); //the  damage overlay opacity is set to 0.5 making it visible, this was done based on the tutorial reference above)
            if (PlayerMovement.PlayerHealth >= 25) //check if player health is more than half
                StartCoroutine(HurtSound()); //if player health is less than half, a player character hurt sound is played expressing moderate pain
            else if (PlayerMovement.PlayerHealth < 25)
                StartCoroutine(HurtSoundLowHP()); //if player health is more than half, a sound expressing excruciating pain is played 
        }
    }

    IEnumerator HurtSound()
    {
        yield return new WaitForSeconds(0.15f); //some time passes from the moment of hitting, this is so the sword sound is started before the hurt sound, and to account for the, albeit short, time it takes for nociceptors to send pain signals and for these to relay a vocal response
        Player.GetComponent<PlayerMovement>().Sounds();
       

    }

    IEnumerator HurtSoundLowHP() 
    {
        yield return new WaitForSeconds(0.15f);
        Player.GetComponent<PlayerMovement>().SoundsLowHP();


    }

}
