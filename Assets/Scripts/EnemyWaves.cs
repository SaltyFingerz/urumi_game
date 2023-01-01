using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    //this script is used to orchestrate when each wave of enemies should start chasing the player
    //the script is attached to the ChaseZone7 EnemyWaves game object in level1.

    //the following are skeletons that are alerted to chase the player upon the player entering specific areas of the level.
    public GameObject SkeletonZone1;
    public GameObject SkeletonZone2;
    public GameObject SkeletonZone3;
    public GameObject SkeletonZone4;
    public GameObject SkeletonZone5;
    public GameObject SkeletonZone6;
    public GameObject SkeletonZone7;

    //the following are skeleton enemies belonging to waves, which are activated one after the killing of another
    public GameObject SkeletonWave2a;
    public GameObject SkeletonWave2b;
    public GameObject SkeletonWave3a;
    public GameObject SkeletonWave3b;
    public GameObject SkeletonWave3c;
    public GameObject SkeletonWave4a;
    public GameObject SkeletonWave4b;
    public GameObject SkeletonWave4c;
    public GameObject SkeletonWave4d;
   
  
    void Update()
    {
        if (PlayerMovement.chase1)
        {
            SkeletonZone1.GetComponent<EnemyController>().ChasePlayer();
        }

        if (PlayerMovement.chase2)
        {
            SkeletonZone2.GetComponent<EnemyController>().ChasePlayer();
        }

        if (PlayerMovement.chase3)
        {
            SkeletonZone3.GetComponent<EnemyController>().ChasePlayer();
        }
        if (PlayerMovement.chase4)
        {
            SkeletonZone4.GetComponent<EnemyController>().ChasePlayer();
        }
        if (PlayerMovement.chase5)
        {
            SkeletonZone5.GetComponent<EnemyController>().ChasePlayer();
        }
        if (PlayerMovement.chase6)
        {
            SkeletonZone6.GetComponent<EnemyController>().ChasePlayer();
        }
        if (PlayerMovement.chase7)
        {
            SkeletonZone7.GetComponent<EnemyController>().ChasePlayer();
        }

        if (!SkeletonZone7.activeSelf)
        {
            SkeletonWave2a.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave2b.GetComponent<EnemyController>().ChasePlayer();
        }
        if (!SkeletonWave2a.activeSelf && !SkeletonWave2b.activeSelf)
        {
            SkeletonWave3a.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave3b.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave3c.GetComponent<EnemyController>().ChasePlayer();
        }
        if (!SkeletonWave3a.activeSelf && !SkeletonWave3b.activeSelf && !SkeletonWave3c.activeSelf)
        {
            SkeletonWave4a.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave4b.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave4c.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave4d.GetComponent<EnemyController>().ChasePlayer();
        }
    }
}
